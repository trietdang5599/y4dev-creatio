let _api = {};
(function(window, undef) {
    'use strict';
    let
        gid = 1,
        noop = function() {},
        document = window.document,
        Blob = window.Blob,
        File = window.File,
        FileReader = window.FileReader,
        FormData = window.FormData,
        XMLHttpRequest = window.XMLHttpRequest,
        jQuery = window.jQuery,
        html5 = typeof File !== "undefined" && typeof FileReader !== "undefined" && typeof FormData !== "undefined",
        cors = html5 && ('withCredentials' in (new XMLHttpRequest)),
        chunked = html5 && !!Blob && !!(Blob.prototype.webkitSlice || Blob.prototype.mozSlice || Blob.prototype.slice),
        normalize = ('' + ''.normalize).indexOf('[native code]') > 0,
        _rinput = /input/i,
        _rdata = /^data:[^,]+,/,
        _toString = {}.toString,
        Math = window.Math,
        _SIZE_CONST = function(pow) {
            pow = new window.Number(Math.pow(1024, pow));
            pow.from = function(sz) { return Math.round(sz * this); };
            return pow;
        },
        _elEvents = {},
        _readerEvents = 'abort progress error load loadend',
        _xhrPropsExport = 'status statusText readyState response responseXML responseText responseBody'.split(' '),
        currentTarget = 'currentTarget',
        preventDefault = 'preventDefault',
        _isArray = function(ar) {
            return ar && ('length' in ar);
        },
        _each = function(obj, fn, ctx) {
            if (obj) {
                if (_isArray(obj)) {
                    for( let i = 0, n = obj.length; i < n; i++) {
                        if (i in obj) {
                            fn.call(ctx, obj[i], i, obj);
                        }
                    }
                }
                else {
                    for( let key in obj) {
                        if (obj.hasOwnProperty(key)) {
                            fn.call(ctx, obj[key], key, obj);
                        }
                    }
                }
            }
        },
        /**
         * Merge the contents of two or more objects together into the first object
         */
        _mergeObjects = function(dst) {
            let args = arguments, _ext = function(val, key) { dst[key] = val; };
            for(let i = 1; i < args.length; i++) {
                _each(args[i], _ext);
            }
            return dst;
        },
        /**
         * Add event listener
         */
        _on = function(el, type, fn) {
            if (el) {
                let uid = _api.uid(el);
                if (!_elEvents[uid]) {
                    _elEvents[uid] = {};
                }
                let isFileReader = (FileReader && el) && (el instanceof FileReader);
                _each(type.split(/\s+/), function(type) {
                    if (jQuery && !isFileReader) {
                        jQuery.event.add(el, type, fn);
                    } else {
                        if (!_elEvents[uid][type]) {
                            _elEvents[uid][type] = [];
                        }
                        _elEvents[uid][type].push(fn);
                        if (el.addEventListener) { el.addEventListener(type, fn, false); }
                        else if (el.attachEvent) { el.attachEvent('on'+type, fn); }
                        else { el['on'+type] = fn; }
                    }
                });
            }
        },
        /**
         * Remove event listener
         */
        _removeEventListener = function(el, type, fn) {
            if (el) {
                let uid = _api.uid(el), events = _elEvents[uid] || {};
                let isFileReader = (FileReader && el) && (el instanceof FileReader);
                _each(type.split(/\s+/), function(type) {
                    if (jQuery && !isFileReader) {
                        jQuery.event.remove(el, type, fn);
                    }
                    else {
                        let fns = events[type] || [], i = fns.length;
                        while( i--) {
                            if (fns[i] === fn) {
                                fns.splice(i, 1);
                                break;
                            }
                        }
                        if (el.addEventListener) { el.removeEventListener(type, fn, false); }
                        else if (el.detachEvent) { el.detachEvent('on'+type, fn); }
                        else { el['on'+type] = null; }
                    }
                });
            }
        },
        _addSingleEventListener = function(el, type, fn) {
            _on(el, type, function _(evt) {
                _removeEventListener(el, type, _);
                fn(evt);
            });
        },
        _normalizeEvent = function(evt) {
            if (!evt.target) { evt.target = window.event && window.event.srcElement || document; }
            if (evt.target.nodeType === 3) { evt.target = evt.target.parentNode; }
            return evt;
        },
        /**
         * FileAPI (core object)
         */
        tmpApi = {
            cors: false,
            html5: true,
            media: false,
            formData: true,
            multiPassResize: true,
            debug: false,
            pingUrl: false,
            withCredentials: true,
            staticPath: './dist/',
            postNameConcat: function(name, idx) {
                return name + (idx != null ? '['+ idx +']' : '');
            },
            ext2mime: {
                jpg: 'image/jpeg',
                tif: 'image/tiff',
                txt: 'text/plain'
            },
            uploadRetry : 0,
            networkDownRetryTimeout : 5000,
            chunkSize : 0,
            chunkUploadRetry : 0,
            chunkNetworkDownRetryTimeout : 2000,
            MB: _SIZE_CONST(2),
            expando: 'fileapi' + (new Date).getTime(),
            uid: function(obj) {
                return obj
                    ? (obj[_api.expando] = obj[_api.expando] || _api.uid())
                    : (++gid, _api.expando + gid);
            },
            log: function() {
                if (_api.debug) {
                    console.log(Array.from(arguments).join(' '));
                }
            },
            getXHR: function() {
                let xhr;
                if (XMLHttpRequest) {
                    xhr = new XMLHttpRequest;
                }
                else if (window.ActiveXObject) {
                    try {
                        xhr = new ActiveXObject('MSXML2.XMLHttp.3.0');
                    } catch (e) {
                        xhr = new ActiveXObject('Microsoft.XMLHTTP');
                    }
                }
                return xhr;
            },
            isArray: _isArray,
            support: {
                dnd: cors && ('ondrop' in document.createElement('div')),
                cors: cors,
                html5: html5,
                chunked: chunked,
                dataURI: true,
                accept: true,
                multiple: true
            },
            event: {
                on: _on,
                off: _removeEventListener,
                one: _addSingleEventListener,
                fix: _normalizeEvent
            },
            throttle: function(fn, delay) {
                let id, args;
                return function _throttle() {
                    args = arguments;
                    if (!id) {
                        fn.apply(window, args);
                        id = setTimeout(function() {
                            id = 0;
                            fn.apply(window, args);
                        }, delay);
                    }
                };
            },
            F: function() {},
            parseJSON: function(str) {
                let json;
                if (window.JSON && JSON.parse) {
                    json = JSON.parse(str);
                }
                else {
                    json = (new Function('return ('+str.replace(/([\r\n])/g, '\\$1')+');'))();
                }
                return json;
            },
            trim: function(str) {
                str = String(str);
                return str.trim ? str.trim() : str.replace(/^\s+|\s+$/g, '');
            },
            queue: function(fn) {
                let
                    _idx = 0,
                    _length = 0,
                    _fail = false,
                    _end = false,
                    queue = {
                        inc: function() {
                            _length++;
                        },
                        next: function() {
                            _idx++;
                            setTimeout(queue.check, 0);
                        },
                        check: function() {
                            (_idx >= _length) && !_fail && queue.end();
                        },
                        isFail: function() {
                            return _fail;
                        },
                        fail: function() {
                            !_fail && fn(_fail = true);
                        },
                        end: function() {
                            if (!_end) {
                                _end = true;
                                fn();
                            }
                        }
                    };
                return queue;
            },
            each: _each,
            afor: function(array, callback) {
                let i = 0, n = array.length;
                if (_isArray(array) && n--) {
                    (function _next() {
                        callback(n != i && _next, array[i], i++);
                    })();
                }
                else {
                    callback(false);
                }
            },
            isFile: function(file) {
                return _toString.call(file) === '[object File]';
            },
            isBlob: function(blob) {
                return _api.isFile(blob) || (_toString.call(blob) === '[object Blob]');
            },
            readAsDataURL: function(file, fn) {
                _readFileAs(file, fn, 'DataURL');
            },
            readAsBinaryString: function(file, fn) {
                _readFileAs(file, fn, 'BinaryString');
            },
            _arrayBufferToBinaryString: function(buffer) {
                const bytes = new Uint8Array(buffer);
                let binary = '';
                for (let i = 0; i < bytes.length; i++) {
                    binary += String.fromCharCode(bytes[i]);
                }
                return binary;
            },
            readAsText: function(file, encoding, fn) {
                if (!fn) {
                    fn = encoding;
                    encoding = 'utf-8';
                }
                _readFileAs(file, fn, 'Text', encoding);
            },
            toDataURL: function(el, type) {
                if (typeof el == 'string') {
                    return el;
                }
                else if (el.toDataURL) {
                    return el.toDataURL(type || 'image/png');
                }
            },
            toBinaryString: function(val) {
                return window.atob(_api.toDataURL(val).replace(_rdata, ''));
            },
            checkFileObj: function(name) {
                let file = {}, accept = _api.accept;
                if (typeof name == 'object') {
                    file = name;
                }
                else {
                    file.name = (name + '').split(/\\|\//g).pop();
                }
                if (file.type == null) {
                    file.type = file.name.split('.').pop();
                }
                _each(accept, function(ext, type) {
                    ext = new RegExp(ext.replace(/\s/g, '|'), 'i');
                    if (ext.test(file.type) || _api.ext2mime[file.type]) {
                        file.type = _api.ext2mime[file.type] || (type.split('/')[0] +'/'+ file.type);
                    }
                });
                return file;
            },
            getDropFiles: function(evt, callback) {
                let
                    files = [],
                    all = [],
                    items,
                    dataTransfer = _getDataTransfer(evt),
                    transFiles = dataTransfer.files,
                    transItems = dataTransfer.items,
                    entrySupport = _isArray(transItems) && transItems[0] && _getAsFileSystemEntry(transItems[0]),
                    queue = _api.queue(function() { callback(files, all); });
                if (entrySupport) {
                    if (normalize && transFiles) {
                        let
                            i = transFiles.length, file, entry;
                        items = new Array(i);
                        while( i--) {
                            file = transFiles[i];
                            try {
                                entry = _getAsFileSystemEntry(transItems[i]);
                            }
                            catch( err) {
                                _api.log('[err] getDropFiles: ', err);
                                entry = null;
                            }
                            if (_isFileSystemEntry(entry)) {
                                // OS filesystems use Unicode Normalization Form D (NFD),
                                // and entry.file(…) can't read the files with the same names
                                if (entry.isDirectory || (entry.isFile && file.name == file.name.normalize('NFC'))) {
                                    items[i] = entry;
                                }
                                else {
                                    items[i] = file;
                                }
                            }
                            else {
                                items[i] = file;
                            }
                        }
                    }
                    else {
                        items = transItems;
                    }
                }
                else {
                    items = transFiles;
                }
                _each(items || [], function(item) {
                    queue.inc();
                    try {
                        _readEntryAsFiles(item, function(err, entryFiles, allEntries) {
                            if (err) {
                                _api.log('[err] getDropFiles:', err);
                            } else {
                                files.push.apply(files, entryFiles);
                            }
                            all.push.apply(all, allEntries);
                            queue.next();
                        });
                    }
                    catch( err) {
                        queue.next();
                        _api.log('[err] getDropFiles: ', err);
                    }
                });
                queue.check();
            },
            getFiles: function(input, filter, callback) {
                let files = [];
                if (input.jquery) {
                    input.each(function() {
                        files = files.concat(_api.getFiles(this));
                    });
                    input = files;
                    files = [];
                }
                if (input.originalEvent) {
                    input = _normalizeEvent(input.originalEvent);
                }
                else if (input.srcElement) {
                    input = _normalizeEvent(input);
                }
                if (input.dataTransfer) {
                    input = input.dataTransfer;
                }
                else if (input.target) {
                    input = input.target;
                }
                if (input.files) {
                    files = input.files;
                    if (!html5) {
                        files[0].blob = input;
                        files[0].iframe = true;
                    }
                }
                else if (!html5 && isInputFile(input)) {
                    if (_api.trim(input.value)) {
                        files = [_api.checkFileObj(input.value)];
                        files[0].blob = input;
                        files[0].iframe = true;
                    }
                }
                else if (_isArray(input)) {
                    files = input;
                }
                return _api.filter(files, function(file) { return !filter || filter.test(file.name); });
            },
            filter: function(input, fn) {
                let result = [], i = 0, n = input.length, val;
                for( ; i < n; i++) {
                    if (i in input) {
                        val = input[i];
                        if (fn.call(val, val, i, input)) {
                            result.push(val);
                        }
                    }
                }
                return result;
            },
            upload: function(options) {
                options = _mergeObjects({
                    jsonp: 'callback',
                    prepare: _api.F,
                    beforeupload: _api.F,
                    upload: _api.F,
                    fileupload: _api.F,
                    fileprogress: _api.F,
                    filecomplete: _api.F,
                    progress: _api.F,
                    complete: _api.F,
                    pause: _api.F,
                    imageOriginal: true,
                    chunkSize: _api.chunkSize,
                    chunkUploadRetry: _api.chunkUploadRetry,
                    uploadRetry: _api.uploadRetry
                }, options);
                let
                    proxyXHR = new _api.XHR(options),
                    dataArray = _api._prepareFilesData(options.files),
                    _this = _api,
                    _total = 0,
                    _loaded = 0,
                    _nextFile,
                    _complete = false;
                _each(dataArray, function(data) {
                    _total += data.size;
                });
                proxyXHR.files = [];
                _each(dataArray, function(data) {
                    proxyXHR.files.push(data.file);
                });
                proxyXHR.total = _total;
                proxyXHR.loaded = 0;
                proxyXHR.filesLeft = dataArray.length;
                options.beforeupload(proxyXHR, options);
                _nextFile = function() {
                    let
                        data = dataArray.shift(),
                        _file = data && data.file,
                        _fileLoaded = false,
                        _fileOptions = _shallowClone(options);
                    proxyXHR.filesLeft = dataArray.length;
                    if (_file && _file.name === _api.expando) {
                        _file = null;
                        _api.log('[warn] FileAPI.upload() — called without files');
                    }
                    if (( proxyXHR.statusText != 'abort' || proxyXHR.current ) && data) {
                        _complete = false;
                        proxyXHR.currentFile = _file;
                        if (_file && options.prepare(_file, _fileOptions) === false) {
                            _nextFile.call(_this);
                            return;
                        }
                        _fileOptions.file = _file;
                        _this._prepareFormData(_fileOptions, data, function(form) {
                            if (!_loaded) {
                                options.upload(proxyXHR, options);
                            }
                            let xhr = new _api.XHR(_mergeObjects({}, _fileOptions, {
                                upload: _file ? function() {
                                    options.fileupload(_file, xhr, _fileOptions);
                                } : noop,
                                progress: _file ? function(evt) {
                                    if (!_fileLoaded) {
                                        _fileLoaded = (evt.loaded === evt.total);
                                        options.fileprogress({
                                            type: 'progress'
                                            , total: data.total = evt.total
                                            , loaded: data.loaded = evt.loaded
                                        }, _file, xhr, _fileOptions);
                                        options.progress({
                                            type: 'progress'
                                            , total: _total
                                            , loaded: proxyXHR.loaded = (_loaded + data.size * (evt.loaded/evt.total)) || 0
                                        }, _file, xhr, _fileOptions);
                                    }
                                } : noop,
                                complete: function(err) {
                                    _each(_xhrPropsExport, function(name) {
                                        proxyXHR[name] = xhr[name];
                                    });
                                    if (_file) {
                                        data.total = (data.total || data.size);
                                        data.loaded = data.total;
                                        if (!err ) {
                                            this.progress(data);
                                            _fileLoaded = true;
                                            _loaded += data.size; // data.size != data.total
                                            proxyXHR.loaded = _loaded;
                                        }
                                        options.filecomplete(err, xhr, _file, _fileOptions);
                                    }
                                    setTimeout(function() {_nextFile.call(_this);}, 0);
                                }
                            }));
                            proxyXHR.abort = function(current) {
                                if (!current) { dataArray.length = 0; }
                                this.current = current;
                                xhr.abort();
                            };
                            xhr.send(form);
                        });
                    }
                    else {
                        let successful = proxyXHR.status == 200 || proxyXHR.status == 201 || proxyXHR.status == 204;
                        options.complete(successful ? false : (proxyXHR.statusText || 'error'), proxyXHR, options);
                        _complete = true;
                    }
                };
                setTimeout(_nextFile, 0);
                proxyXHR.append = function(files, first) {
                    files = _api._prepareFilesData([].concat(files));
                    _each(files, function(data) {
                        _total += data.size;
                        proxyXHR.files.push(data.file);
                        if (first) {
                            dataArray.unshift(data);
                        } else {
                            dataArray.push(data);
                        }
                    });
                    proxyXHR.statusText = "";
                    if (_complete) {
                        _nextFile.call(_this);
                    }
                };
                proxyXHR.remove = function(file) {
                    let i = dataArray.length, _file;
                    while( i--) {
                        if (dataArray[i].file == file) {
                            _file = dataArray.splice(i, 1);
                            _total -= _file.size;
                        }
                    }
                    return _file;
                };
                return proxyXHR;
            },
            _prepareFilesData: function(data) {
                let files = [], oFiles = {};
                if (isInputFile(data)) {
                    let tmp = _api.getFiles(data);
                    oFiles[data.name || 'file'] = data.getAttribute('multiple') !== null ? tmp : tmp[0];
                }
                else if (_isArray(data) && isInputFile(data[0])) {
                    _each(data, function(input) {
                        oFiles[input.name || 'file'] = _api.getFiles(input);
                    });
                }
                else {
                    oFiles = data;
                }
                _each(oFiles, function add(file, name) {
                    if (_isArray(file)) {
                        _each(file, function(file) {
                            add(file, name);
                        });
                    }
                    else if (file && (file.name || file.image)) {
                        files.push({
                            name: name, file: file, size: file.size, total: file.size, loaded: 0
                        });
                    }
                });
                if (!files.length) {
                    files.push({ file: { name: _api.expando } });
                }
                return files;
            },
            _prepareFormData: function(options, data, fn) {
                let
                    file = data.file,
                    name = data.name,
                    filename = file.name,
                    Form = new _api.Form,
                    queue = _api.queue(function() { fn(Form); }),
                    postNameConcat = _api.postNameConcat;
                _each(options.data, function add(val, name) {
                    if (typeof val == 'object') {
                        _each(val, function(v, i) {
                            add(v, postNameConcat(name, i));
                        });
                    }
                    else {
                        Form.append(name, val);
                    }
                });
                if (filename !== _api.expando) {
                    Form.append(name, file, filename);
                }
                queue.check();
            },
            reset: function(inp, notRemove) {
                let parent, clone;
                if (jQuery) {
                    clone = jQuery(inp).clone(true).insertBefore(inp).val('')[0];
                    if (!notRemove) {
                        jQuery(inp).remove();
                    }
                } else {
                    parent = inp.parentNode;
                    clone = parent.insertBefore(inp.cloneNode(true), inp);
                    clone.value = '';
                    if (!notRemove) {
                        parent.removeChild(inp);
                    }
                    _each(_elEvents[_api.uid(inp)], function(fns, type) {
                        _each(fns, function(fn) {
                            _removeEventListener(inp, type, fn);
                            _on(clone, type, fn);
                        });
                    });
                }
                return clone;
            },
        };
    _mergeObjects(_api, tmpApi);

    function _emitEvent(target, fn, name, res, ext) {
        let evt = {
            type: name.type || name,
            target: target,
            result: res
        };
        _mergeObjects(evt, ext);
        fn(evt);
    }

    function _readFileAs(file, fn, method, encoding) {
        let Reader = new FileReader;
        _on(Reader, _readerEvents, function _fn(evt) {
            let type = evt.type;
            if (type == 'progress') {
                _emitEvent(file, fn, evt, evt.target.result, { loaded: evt.loaded, total: evt.total });
            }
            else if (type == 'loadend') {
                _removeEventListener(Reader, _readerEvents, _fn);
                Reader = null;
            }
            else {
                _emitEvent(file, fn, evt, evt.target.result);
            }
        });
        try {
            if (encoding) {
                Reader['readAs' + method](file, encoding);
            }
            else {
                Reader['readAs' + method](file);
            }
        }
        catch (err) {
            _emitEvent(file, fn, 'error', undef, { error: err.toString() });
        }
    }

    function _isFileSystemEntry(item) {
        return item && (item.isFile || item.isDirectory);
    }

    function _getAsFileSystemEntry(item) {
        return item.webkitGetAsEntry();
    }

    function _readEntryAsFiles(entry, callback) {
        if (!entry) {
            let err = new Error('invalid entry');
            entry = new Object(entry);
            entry.error = err;
            callback(err.message, [], [entry]);
        }
        else if (entry.isFile) {
            entry.file(function(file) {
                file.fullPath = entry.fullPath;
                callback(false, [file], [file]);
            }, function(err) {
                entry.error = err;
                callback('FileError.code: ' + err.code, [], [entry]);
            });
        }
        else if (entry.isDirectory) {
            let
                reader = entry.createReader(),
                firstAttempt = true,
                files = [],
                all = [entry];
            let onerror = function(err) {
                entry.error = err;
                callback('DirectoryError.code: ' + err.code, files, all);
            };
            let ondone = function ondone(entries) {
                if (firstAttempt) {
                    firstAttempt = false;
                    if (!entries.length) {
                        entry.error = new Error('directory is empty');
                    }
                }
                if (entries.length) {
                    _api.afor(entries, function(next, entry) {
                        _readEntryAsFiles(entry, function(err, entryFiles, allEntries) {
                            if (!err) {
                                files = files.concat(entryFiles);
                            }
                            all = all.concat(allEntries);

                            if (next) {
                                next();
                            }
                            else {
                                reader.readEntries(ondone, onerror);
                            }
                        });
                    });
                }
                else {
                    callback(false, files, all);
                }
            };
            reader.readEntries(ondone, onerror);
        }
        else {
            _readEntryAsFiles(_getAsFileSystemEntry(entry), callback);
        }
    }

    function _shallowClone(obj) {
        let copy = {};
        _each(obj, function(val, key) {
            if (val && (typeof val === 'object') && (val.nodeType === void 0)) {
                val = _mergeObjects({}, val);
            }
            copy[key] = val;
        });
        return copy;
    }

    function isInputFile(el) {
        return _rinput.test(el && el.tagName);
    }

    function _getDataTransfer(evt) {
        return (evt.originalEvent || evt || '').dataTransfer || {};
    }

    /**
     * Drag-n-Drop special event
     * @param {HTMLElement} el
     * @param {Function}  onHover
     * @param {Function}  onDrop
     */
    _api.event.dnd = function(el, onHover, onDrop) {
        let _id, _type;
        if (!onDrop) {
            onDrop = onHover;
            onHover = _api.F;
        }
        _on(el, 'dragenter dragleave dragover', onHover.ff = onHover.ff || function(evt) {
            let
                types = _getDataTransfer(evt).types,
                i = types && types.length,
                debounceTrigger = false;
            while( i--) {
                if (~types[i].indexOf('File')) {
                    evt[preventDefault]();
                    if (_type !== evt.type) {
                        _type = evt.type;
                        if (_type != 'dragleave') {
                            onHover.call(evt[currentTarget], true, evt);
                        }
                        debounceTrigger = true;
                    }
                    break;
                }
            }
            if (debounceTrigger) {
                clearTimeout(_id);
                _id = setTimeout(function() {
                    onHover.call(evt[currentTarget], _type != 'dragleave', evt);
                }, 50);
            }
        });
        _on(el, 'drop', onDrop.ff = onDrop.ff || function(evt) {
            evt[preventDefault]();
            _type = 0;
            onHover.call(evt[currentTarget], false, evt);
            _api.getDropFiles(evt, function(files, all) {
                onDrop.call(evt[currentTarget], files, all, evt);
            });
        });
    };

    /**
     * Remove drag-n-drop
     * @param {HTMLElement} el
     * @param {Function} onHover
     * @param {Function} onDrop
     */
    _api.event.dnd.off = function(el, onHover, onDrop) {
        _removeEventListener(el, 'dragenter dragleave dragover', onHover.ff);
        _removeEventListener(el, 'drop', onDrop.ff);
    };

    if (jQuery && !jQuery.fn.dnd) {
        jQuery.fn.dnd = function(onHover, onDrop) {
            return _api.each(function() {
                _api.event.dnd(this, onHover, onDrop);
            });
        };
        jQuery.fn.offdnd = function(onHover, onDrop) {
            return _api.each(function() {
                _api.event.dnd.off(this, onHover, onDrop);
            });
        };
    }

    const proto = {
        getFiles: _api.getFiles,
        readAsDataURL: _api.readAsDataURL,
        upload: _api.upload,
        MB: _api.MB,
        event: {
            on: _api.event.on,
            off: _api.event.off,
            one: _api.event.one,
            fix: _api.event.fix,
            dnd: _api.event.dnd
        },
        readAsBinaryString: _api.readAsBinaryString,
        readAsText: _api.readAsText
    }
    // @export
    window.FileAPI = _mergeObjects(proto, window.FileAPI);
    _api.log('protocol: ' + window.location.protocol);
})(window, void 0);

(function(api, window) {
    "use strict";
    let
        document = window.document,
        FormData = window.FormData,
        Form = function() { this.items = []; },
        encodeURIComponent = window.encodeURIComponent;
    Form.prototype = {
        append: function(name, blob, file, type) {
            this.items.push({
                name: name,
                blob: blob && blob.blob || (blob == void 0 ? '' : blob),
                file: blob && (file || blob.name),
                type: blob && (type || blob.type)
            });
        },
        each: function(fn) {
            let i = 0, n = this.items.length;
            for( ; i < n; i++) {
                fn.call(this, this.items[i]);
            }
        },
        toData: function(fn, options) {
            options._chunked = api.support.chunked && options.chunkSize > 0 && api.filter(this.items, function(item) { return item.file; }).length == 1;
            if (!api.support.html5) {
                api.log('FileAPI.Form.toHtmlData');
                this.toHtmlData(fn);
            }
            else if (!api.formData || this.multipart || !FormData) {
                api.log('FileAPI.Form.toMultipartData');
                this.toMultipartData(fn);
            }
            else if (options._chunked) {
                api.log('FileAPI.Form.toPlainData');
                this.toPlainData(fn);
            }
            else {
                api.log('FileAPI.Form.toFormData');
                this.toFormData(fn);
            }
        },
        _to: function(data, complete, next, arg) {
            let queue = api.queue(function() {
                complete(data);
            });
            this.each(function(file) {
                try{
                    next(file, data, queue, arg);
                }
                catch( err) {
                    api.log('FileAPI.Form._to: ' + err.message);
                    complete(err);
                }
            });
            queue.check();
        },
        toHtmlData: function(fn) {
            this._to(document.createDocumentFragment(), fn, function(file, data/**DocumentFragment*/) {
                let blob = file.blob, hidden;
                if (file.file) {
                    api.reset(blob, true);
                    blob.name = file.name;
                    blob.disabled = false;
                    data.appendChild(blob);
                }
                else {
                    hidden = document.createElement('input');
                    hidden.name = file.name;
                    hidden.type = 'hidden';
                    hidden.value = blob;
                    data.appendChild(hidden);
                }
            });
        },
        toPlainData: function(fn) {
            this._to({}, fn, function(file, data, queue) {
                if (file.file) {
                    data.type = file.file;
                }
                if (file.blob.toBlob) {
                    queue.inc();
                    _convertFileForUpload(file, function(file, blob) {
                        data.name = file.name;
                        data.file = blob;
                        data.size = blob.length;
                        data.type = file.type;
                        queue.next();
                    });
                }
                else if (file.file) {
                    data.name = file.blob.name;
                    data.file = file.blob;
                    data.size = file.blob.size;
                    data.type = file.type;
                }
                else {
                    if (!data.params) {
                        data.params = [];
                    }
                    data.params.push(encodeURIComponent(file.name) +"="+ encodeURIComponent(file.blob));
                }
                data.start = -1;
                data.end = data.file && data.file.FileAPIReadPosition || -1;
                data.retry = 0;
            });
        },
        toFormData: function(fn) {
            this._to(new FormData, fn, function(file, data, queue) {
                if (file.blob && file.blob.toBlob) {
                    queue.inc();
                    _convertFileForUpload(file, function(file, blob) {
                        data.append(file.name, blob, file.file);
                        queue.next();
                    });
                }
                else if (file.file) {
                    data.append(file.name, file.blob, file.file);
                }
                else {
                    data.append(file.name, file.blob);
                }
                if (file.file) {
                    data.append('_'+file.name, file.file);
                }
            });
        },
        toMultipartData: function(fn) {
            this._to([], fn, function(file, data, queue, boundary) {
                queue.inc();
                _convertFileForUpload(file, function(file, blob) {
                    data.push(
                        '--_' + boundary + ('\r\nContent-Disposition: form-data; name="'+ file.name +'"'+ (file.file ? '; filename="'+ encodeURIComponent(file.file) +'"' : '')
                            + (file.file ? '\r\nContent-Type: '+ (file.type || 'application/octet-stream') : '')
                            + '\r\n'
                            + '\r\n'+ (file.file ? blob : encodeURIComponent(blob))
                            + '\r\n')
                    );
                    queue.next();
                }, true);
            }, api.expando);
        }
    };

    function _convertFileForUpload(file, fn, useBinaryString) {
        let blob = file.blob, filename = file.file;
        if (filename) {
            if (!blob.toDataURL) {
                api.readAsBinaryString(blob, function(evt) {
                    if (evt.type == 'load') {
                        fn(file, evt.result);
                    }
                });
                return;
            }
            let
                mime = { 'image/jpeg': '.jpe?g', 'image/png': '.png' },
                type = mime[file.type] ? file.type : 'image/png',
                ext = mime[type] || '.png',
                quality = blob.quality || 1;
            if (!filename.match(new RegExp(ext+'$', 'i'))) {
                filename += ext.replace('?', '');
            }
            file.file = filename;
            file.type = type;
            if (!useBinaryString && blob.toBlob) {
                blob.toBlob(function(blob) {
                    fn(file, blob);
                }, type, quality);
            }
            else {
                fn(file, api.toBinaryString(blob.toDataURL(type, quality)));
            }
        }
        else {
            fn(file, blob);
        }
    }
    // @export
    api.Form = Form;
})(_api, window);

(function(window, api) {
    "use strict";
    let
        noop = function() {},
        document = window.document,
        XHR = function(options) {
            this.uid = api.uid();
            this.xhr = {
                abort: noop
                , getResponseHeader: noop
                , getAllResponseHeaders: noop
            };
            this.options = options;
        },
        _xhrResponsePostfix = { '': 1, XML: 1, Text: 1, Body: 1 };
    XHR.prototype = {
        status: 0,
        statusText: '',
        constructor: XHR,
        getResponseHeader: function(name) {
            return this.xhr.getResponseHeader(name);
        },
        getAllResponseHeaders: function() {
            return this.xhr.getAllResponseHeaders() || {};
        },
        end: function(status, statusText) {
            let _this = this, options = _this.options;
            _this.end =
                _this.abort = noop;
            _this.status = status;
            if (statusText) {
                _this.statusText = statusText;
            }
            api.log('xhr.end:', status, statusText);
            options.complete(status == 200 || status == 201 ? false : _this.statusText || 'unknown', _this);
            if (_this.xhr && _this.xhr.node) {
                setTimeout(function() {
                    let node = _this.xhr.node;
                    try { node.parentNode.removeChild(node); } catch (e) {}
                    try { delete window[_this.uid]; } catch (e) {}
                    window[_this.uid] = _this.xhr.node = null;
                }, 9);
            }
        },
        abort: function() {
            this.end(0, 'abort');
            if (this.xhr) {
                this.xhr.aborted = true;
                this.xhr.abort();
            }
        },
        send: function(FormData) {
            let _this = this, options = this.options;
            FormData.toData(function(data) {
                if (data instanceof Error) {
                    _this.end(0, data.message);
                }
                else{
                    options.upload(options, _this);
                    _this._send.call(_this, options, data);
                }
            }, options);
        },
        _send: function(options, data) {
            let _this = this,
                xhr,
                uid = _this.uid,
                onLoadFnName = _this.uid + "Load",
                url = options.url;
            api.log('XHR._send:', data);
            if (!options.cache) {
                url += (~url.indexOf('?') ? '&' : '?') + api.uid();
            }
            if (data.nodeName) {
                let jsonp = options.jsonp;
                url = url.replace(/([a-z]+)=(\?)/i, '$1='+uid);
                options.upload(options, _this);
                let
                    onPostMessage = function(evt) {
                        if (~url.indexOf(evt.origin)) {
                            try {
                                let result = api.parseJSON(evt.data);
                                if (result.id == uid) {
                                    complete(result.status, result.statusText, result.response);
                                }
                            } catch( err) {
                                complete(0, err.message);
                            }
                        }
                    },
                    complete = window[uid] = function(status, statusText, response) {
                        _this.readyState = 4;
                        _this.responseText = response;
                        _this.end(status, statusText);
                        api.event.off(window, 'message', onPostMessage);
                        window[uid] = xhr = transport = window[onLoadFnName] = null;
                    };
                _this.xhr.abort = function() {
                    try {
                        if (transport.stop) { transport.stop(); }
                        else if (transport.contentWindow.stop) { transport.contentWindow.stop(); }
                        else { transport.contentWindow.document.execCommand('Stop'); }
                    }
                    catch (er) {}
                    complete(0, "abort");
                };
                api.event.on(window, 'message', onPostMessage);
                window[onLoadFnName] = function() {
                    try {
                        let
                            win = transport.contentWindow,
                            doc = win.document,
                            result = win.result || api.parseJSON(doc.body.innerHTML);
                        complete(result.status, result.statusText, result.response);
                    } catch (e) {
                        api.log('[transport.onload]', e);
                    }
                };
                xhr = document.createElement('div');
                xhr.innerHTML = '<form target="'+ uid +'" action="'+ url +'" method="POST" enctype="multipart/form-data" style="position: absolute; top: -1000px; overflow: hidden; width: 1px; height: 1px;">'
                    + '<iframe name="'+ uid +'" src="javascript:false;" onload="window.' + onLoadFnName + ' && ' + onLoadFnName + '();"></iframe>'
                    + (jsonp && (options.url.indexOf('=?') < 0) ? '<input value="'+ uid +'" name="'+jsonp+'" type="hidden"/>' : '')
                    + '</form>'
                ;
                let
                    form = xhr.getElementsByTagName('form')[0],
                    transport = xhr.getElementsByTagName('iframe')[0];
                form.appendChild(data);
                api.log(form.parentNode.innerHTML);
                document.body.appendChild(xhr);
                _this.xhr.node = xhr;
                _this.readyState = 2;
                try {
                    form.submit();
                } catch (err) {
                    api.log('iframe.error: ' + err);
                }
                form = null;
            }
            else {
                url = url.replace(/([a-z]+)=(\?)&?/i, '');
                if (this.xhr && this.xhr.aborted) {
                    api.log("Error: already aborted");
                    return;
                }
                xhr = _this.xhr = api.getXHR();
                if (data.params) {
                    url += (url.indexOf('?') < 0 ? "?" : "&") + data.params.join("&");
                }
                xhr.open('POST', url, true);
                if (api.withCredentials) {
                    xhr.withCredentials = "true";
                }
                if (!options.headers || !options.headers['X-Requested-With']) {
                    xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
                }
                api.each(options.headers, function(val, key) {
                    xhr.setRequestHeader(key, val);
                });
                if ( options._chunked ) {
                    if (xhr.upload) {
                        xhr.upload.addEventListener('progress', api.throttle(function(/**Event*/evt) {
                            if (!data.retry) {
                                options.progress({
                                    type:            evt.type
                                    , total:        data.size
                                    , loaded:        data.start + evt.loaded
                                    , totalSize: data.size
                                }, _this, options);
                            }
                        }, 100), false);
                    }
                    xhr.onreadystatechange = function() {
                        let lkb = parseInt(xhr.getResponseHeader('X-Last-Known-Byte'), 10);
                        _this.status = xhr.status;
                        _this.statusText = xhr.statusText;
                        _this.readyState = xhr.readyState;
                        if (xhr.readyState == 4) {
                            for( let k in _xhrResponsePostfix) {
                                _this['response'+k] = xhr['response'+k];
                            }
                            xhr.onreadystatechange = null;
                            if (!xhr.status || xhr.status - 201 > 0) {
                                api.log("Error: " + xhr.status);
                                if (((!xhr.status && !xhr.aborted) || 500 == xhr.status || 416 == xhr.status) && ++data.retry <= options.chunkUploadRetry) {
                                    let delay = xhr.status ? 0 : api.chunkNetworkDownRetryTimeout;
                                    options.pause(data.file, options);
                                    api.log("X-Last-Known-Byte: " + lkb);
                                    if (lkb) {
                                        data.end = lkb;
                                    } else {
                                        data.end = data.start - 1;
                                        if (416 == xhr.status) {
                                            data.end = data.end - options.chunkSize;
                                        }
                                    }
                                    setTimeout(function() {
                                        _this._send(options, data);
                                    }, delay);
                                } else {
                                    _this.end(xhr.status);
                                }
                            } else {
                                data.retry = 0;
                                if (data.end == data.size - 1) {
                                    _this.end(xhr.status);
                                } else {
                                    api.log("X-Last-Known-Byte: " + lkb);
                                    if (lkb) {
                                        data.end = lkb;
                                    }
                                    data.file.FileAPIReadPosition = data.end;

                                    setTimeout(function() {
                                        _this._send(options, data);
                                    }, 0);
                                }
                            }
                            xhr = null;
                        }
                    };
                    data.start = data.end + 1;
                    data.end = Math.max(Math.min(data.start + options.chunkSize, data.size) - 1, data.start);
                    let
                        file = data.file,
                        slice = (file.slice || file.mozSlice || file.webkitSlice).call(file, data.start, data.end + 1);
                    if (data.size && !slice.size) {
                        setTimeout(function() {
                            _this.end(-1);
                        });
                    } else {
                        xhr.setRequestHeader("Content-Range", "bytes " + data.start + "-" + data.end + "/" + data.size);
                        xhr.setRequestHeader("Content-Disposition", 'attachment; filename=' + encodeURIComponent(data.name));
                        xhr.setRequestHeader("Content-Type", data.type || "application/octet-stream");
                        xhr.send(slice);
                    }
                    file = slice = null;
                } else {
                    if (xhr.upload) {
                        xhr.upload.addEventListener('progress', api.throttle(function(/**Event*/evt) {
                            options.progress(evt, _this, options);
                        }, 100), false);
                    }
                    xhr.onreadystatechange = function() {
                        _this.status = xhr.status;
                        _this.statusText = xhr.statusText;
                        _this.readyState = xhr.readyState;

                        if (xhr.readyState == 4) {
                            for( let k in _xhrResponsePostfix) {
                                _this['response'+k] = xhr['response'+k];
                            }
                            xhr.onreadystatechange = null;
                            if (!xhr.status || xhr.status > 201) {
                                api.log("Error: " + xhr.status);
                                if (((!xhr.status && !xhr.aborted) || 500 == xhr.status) && (options.retry || 0) < options.uploadRetry) {
                                    options.retry = (options.retry || 0) + 1;
                                    let delay = api.networkDownRetryTimeout;
                                    options.pause(options.file, options);
                                    setTimeout(function() {
                                        _this._send(options, data);
                                    }, delay);
                                } else {
                                    _this.end(xhr.status);
                                }
                            } else {
                                _this.end(xhr.status);
                            }
                            xhr = null;
                        }
                    };
                    if (api.isArray(data)) {
                        xhr.setRequestHeader('Content-Type', 'multipart/form-data; boundary=_'+api.expando);
                        let rawData = data.join('') +'--_'+ api.expando +'--';
                        /** @namespace xhr.sendAsBinary https://developer.mozilla.org/ru/XMLHttpRequest#Sending_binary_content */
                        if (xhr.sendAsBinary) {
                            xhr.sendAsBinary(rawData);
                        }
                        else {
                            let bytes = Array.prototype.map.call(rawData, function(c) { return c.charCodeAt(0) & 0xff; });
                            xhr.send(new Uint8Array(bytes).buffer);

                        }
                    } else {
                        xhr.send(data);
                    }
                }
            }
        }
    };
    // @export
    api.XHR = XHR;
})(window, _api);

if (typeof define === "function" && define.amd) { define("FileAPI", [], function() { return FileAPI; }); }