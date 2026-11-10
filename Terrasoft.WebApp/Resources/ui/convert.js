const { generate } = require("astring");
const acorn = require("acorn");
const walk = require("acorn-walk");
const fs = require("fs");
const find = require("find");
const { basename, dirname } = require("path");
const files = find.fileSync(new RegExp(process.argv.slice(2)), ".");
const processFile = (content, path) => {
   const fileName = basename(path);
   const ast = acorn.parse(
      content
         .replace(/test\.chain/gi, "Terrasoft.chain")
         .replace(/test\./gi, "")
         .replace(/\(test\)/gi, "()")
   );
 
   const getBeforeAllAst = addRequire =>
      acorn.parse(
         `beforeAll(${
            addRequire
               ? `(done) => require([], () => {
    done();
  })`
               : `() => {}`
         })`
      );
   const getRootTestAat = acorn.parse(
      `const getRootTest = window.getRootTest.bind(this, "${fileName}")`
   );
   const okAst = () => acorn.parse(`expect().toBeTruthy()`);
   const isStrictAst = () => acorn.parse(`expect().toEqual()`);
   const isAst = () => acorn.parse(`expect().toEqual()`);
   const isNotAst = () => acorn.parse(`expect().not.toEqual()`);
   const isGreaterAst = () => acorn.parse(`expect().toBeGreaterThan()`);
   const isLessAst = () => acorn.parse(`expect().toBeLessThan()`);
   const likeAst = () => acorn.parse(`expect().toMatch()`);
   const isCalledOnceAst = () =>
      acorn.parse(`expect().toHaveBeenCalledTimes(1)`);
   const isCalledAst = () => acorn.parse(`expect().toHaveBeenCalled()`);
   const isntCalledAst = () => acorn.parse(`expect().not.toHaveBeenCalled()`);
   const isCalledNTimesAst = () =>
      acorn.parse(`expect().toHaveBeenCalledTimes()`);
   const throwsOkAst = () => acorn.parse(`expect().toThrowError()`);
   const isInstanceOfAst = () => acorn.parse(`expect().toBeInstanceOf()`);
   const isNotStrictAst = () => acorn.parse(`expect().not.toEqual()`);
   throwsOkAst.execute = (node, newNode) => {
      if (node.arguments["1"].raw == '""') {
         newNode.expression.callee.property.name = "toThrow";
      } else {
         newNode.expression.arguments.push(node.arguments[1]);
      }
   };
   isCalledAst.execute = () => {};
   const notOkAst = () => acorn.parse(`expect().toBe(false)`);
   isInstanceOfAst.execute = (node, newNode) => {
      if (typeof node.arguments["1"].raw == "string") {
         const parts = node.arguments["1"].raw.replace(/"/, "").split(".");
         newNode.expression.arguments.push({
            type: "MemberExpression",
            object: {
               type: "Identifier",
               name: parts[0]
            },
            property: {
               type: "Identifier",
               name: parts[1]
            },
            computed: false
         });
      } else {
         newNode.expression.arguments.push(node.arguments[1]);
      }
   };
 
   // Method replace map
   const astMap = {
      isStrict: isStrictAst,
      is: isAst,
      isGreater: isGreaterAst,
      isCalledOnce: isCalledOnceAst,
      throwsOk: throwsOkAst,
      isInstanceOf: isInstanceOfAst,
      isDeeplyStrict: isStrictAst,
      isDateEqual: isAst,
      notOk: notOkAst,
      isCalledNTimes: isCalledNTimesAst,
      isLess: isLessAst,
      like: likeAst,
      isCalled: isCalledAst,
      isNotStrict: isNotStrictAst,
      isNot: isNotAst,
      isntCalled: isntCalledAst
   };
 
   const testFunctions = [
      "beforeEach",
      "beforeAll",
      "afterEach",
      "afterAll",
      "it",
      "describe",
      "fit",
      "fdescribe",
      "xit",
      "xdescribe"
   ];
 
   const newAst = acorn.parse(``);
   try {
      const moveInitializationToBeforeAll = node => {
         if (node.callee.name === "describe") {
            const newAst = acorn.parse(``);
            const describeBody = node.arguments["1"].body.body;
            if (describeBody.processed) return;
            const filter = x =>
               !x.expression ||
               !x.expression.callee ||
               !testFunctions.includes(x.expression.callee.name);
            const processed = [];
            const beforeAllAst = getBeforeAllAst(false);
            if (describeBody.some(filter)) {
               for (const expression of describeBody.filter(filter)) {
                  switch (expression.type) {
                     case "CallExpression":
                     case "ExpressionStatement":
                        beforeAllAst.body["0"].expression.arguments[
                           "0"
                        ].body.body.push(expression);
                        processed.push(expression);
                        break;
                     case "VariableDeclaration":
                        const declarationToSplit = expression.declarations.filter(
                           x => x.init
                        );
                        newAst.body.push({
                           type: "VariableDeclaration",
                           declarations: expression.declarations.map(
                              x => ({
                                 ...x,
                                 init: null
                              })
                           ),
                           kind:
                              expression.kind !== "const"
                                 ? expression.kind
                                 : "let"
                        });
                        if (declarationToSplit.length) {
                           beforeAllAst.body["0"].expression.arguments[
                              "0"
                           ].body.body.push(
                              ...declarationToSplit.map(x => ({
                                 type: "ExpressionStatement",
                                 expression: {
                                    type: "AssignmentExpression",
                                    operator: "=",
                                    left: {
                                       type: "Identifier",
                                       name: x.id.name
                                    },
                                    right: x.init
                                 }
                              }))
                           );
                        }
                        processed.push(expression);
                        break;
                  }
               }
            }
            const testCases = [
               ...describeBody.filter(x => !processed.includes(x))
            ];
            const beforeAsts = beforeAllAst.body["0"].expression.arguments[
               "0"
            ].body.body.length
               ? [beforeAllAst]
               : [];
            describeBody.splice(
               0,
               describeBody.length,
               ...newAst.body,
               ...beforeAsts,
               ...testCases
            );
         }
      };
      const fixAsyncBeforeEach = node => {
         if (node.callee.name === "beforeEach") {
            if (node.arguments.length > 1) {
               node.arguments.splice(1, node.arguments.length - 1);
               node.arguments["0"].params.splice(0, 1);
            }
         }
      };
      const useToHaveBeenCalledTimes = node => {
         if (
            node.callee &&
            node.callee.property &&
            node.callee.property.name === "toHaveBeenCalled"
         ) {
            if (
               node.arguments.length &&
               parseInt(node.arguments["0"].raw).toString() ===
                  node.arguments["0"].raw
            ) {
               node.callee.property.name = "toHaveBeenCalledTimes";
            }
         }
      };
      const initialInvoke = ast.body[0].expression;
      if (
         content.indexOf("teardown") === -1 &&
         initialInvoke.callee.name === "require"
      ) {
         const beforeAllAst = getBeforeAllAst(true);
         const beforeAll = beforeAllAst.body["0"].expression;
         const requireInvocation = beforeAll.arguments["0"].body;
         const requireArrayArgs = requireInvocation.arguments["0"];
         for (const dep of initialInvoke.arguments["0"].elements) {
            requireArrayArgs.elements.push(dep);
         }
         const startTest = initialInvoke.arguments["1"].body.body.find(
            x =>
               x.expression &&
               x.expression.callee &&
               x.expression.callee.name == "startTest"
         );
         const firstDescribe = startTest.expression.arguments[
            "0"
         ].body.body.find(
            x =>
               x.expression &&
               x.expression.callee &&
               x.expression.callee.name == "describe"
         );
         newAst.body.push(firstDescribe);
         beforeAllAst.body["0"].expression.arguments["0"].body.arguments[
            "1"
         ].body.body.unshift(
            ...startTest.expression.arguments["0"].body.body.filter(
               x =>
                  x != firstDescribe &&
                  !testFunctions.includes(
                     x.expression &&
                        x.expression.callee &&
                        x.expression.callee.name
                  )
            )
         );
         firstDescribe.expression.arguments["1"].body.body.unshift(
            ...beforeAllAst.body,
            ...getRootTestAat.body,
            ...startTest.expression.arguments["0"].body.body.filter(
               x =>
                  x != firstDescribe &&
                  testFunctions.includes(
                     x.expression &&
                        x.expression.callee &&
                        x.expression.callee.name
                  )
            )
         );
 
         const convertToJasmineExpectation = node => {
            if (node.callee.name === "ok") {
               const newNode = { ...okAst().body[0] };
               newNode.expression.callee.object.arguments.push(
                  node.arguments[0]
               );
               for (const key of Object.keys(node)) {
                  delete node[key];
               }
               Object.assign(node, newNode);
            } else if (Object.keys(astMap).includes(node.callee.name)) {
               const newNode = { ...astMap[node.callee.name]().body[0] };
               let calleeArgs = newNode.expression.callee.object.arguments;
               if (
                  "object" in newNode.expression.callee.object &&
                  newNode.expression.callee.object.property.name === "not"
               ) {
                  calleeArgs =
                     newNode.expression.callee.object.object.arguments;
               }
               calleeArgs.push(node.arguments[0]);
               if (!newNode.expression.arguments.length) {
                  if (astMap[node.callee.name].execute) {
                     astMap[node.callee.name].execute(node, newNode);
                  } else {
                     newNode.expression.arguments.push(
                        node.arguments[1]
                     );
                  }
               }
               for (const key of Object.keys(node)) {
                  delete node[key];
               }
               Object.assign(node, newNode);
            }
         };
 
         walk.simple(newAst, {
            CallExpression: convertToJasmineExpectation
         });
         walk.simple(newAst, {
            CallExpression: moveInitializationToBeforeAll
         });
         walk.simple(newAst, {
            CallExpression: fixAsyncBeforeEach
         });
         walk.simple(newAst, {
            CallExpression: useToHaveBeenCalledTimes
         });
         let newContent = generate(newAst);
 
         newContent = newContent.replace(/;;/g, ";");
         newContent = newContent.replace(/\.and\./g, ".");
         newContent = newContent.replace(
            /\.returnValue/g,
            ".and.returnValue"
         );
         newContent = newContent.replace(
            /\.callThrough/g,
            ".and.callThrough"
         );
         newContent = newContent.replace(/\.callFake/g, ".and.callFake");
         newContent = newContent.replace(/\.stub/g, ".and.stub");
         newContent = newContent.replace(/createSpy/g, "jasmine.createSpy");
         newContent = newContent.replace(/test =>/g, "() =>");
         newContent = newContent.replace(/any\(\)/g, "jasmine.anything()");
         newContent = newContent.replace(/any\(/g, "jasmine.any(");
         //newContent = newContent.replace(/test/g, "this");
         newContent = newContent.replace(/tests/g, "spec");
         newContent = newContent.replace(/\(test\)/g, "()");
         return newContent;
      }
   } catch (e) {
      console.error(e);
   }
};
const bdd = [];
const nonBdd = [];
const create = [];
for (let path of files) {
   const content = fs.readFileSync(path, "utf-8");
   const newContent = processFile(content, path);
   path = path.replace(".tests.js", ".spec.js");
   fs.mkdirSync(dirname(path), { recursive: true });
   if (!fs.existsSync(path) && newContent) {
      create.push(basename(path));
      fs.writeFileSync(path, newContent || content);
   }
   if (newContent) {
      bdd.push(basename(path));
   } else {
      nonBdd.push(basename(path));
      if (fs.existsSync(path)) fs.unlinkSync(path);
   }
}
console.log("bdd", bdd);
console.log("non", nonBdd);
console.log("create", create);