Ext.ns("Terrasoft.utils.guid");

/**
 * @singleton
 */

/**
 * Generates GUID value according to the provided format specifier.
 * @param {String} [format] A single format specifier that indicates how to format the value of this Guid.
 * The format parameter can be "N", "D", "B", "P". If format is null or an empty string (""), "D" is used.
 * Example:
 *
 *     Terrasoft.formatGUID(value) returns 00000000-0000-0000-0000-000000000000
 *     Terrasoft.formatGUID(value, "N") returns 00000000000000000000000000000000
 *     Terrasoft.formatGUID(value, "B") returns {00000000-0000-0000-0000-000000000000}
 *     Terrasoft.formatGUID(value, "P") returns (00000000-0000-0000-0000-000000000000)
 *
 */
Terrasoft.generateGUID = function(format) {
	const idGenerator = Ext.data.IdGenerator.get("uuid");
	const id = idGenerator.generate();
	return Terrasoft.formatGUID(id, format);
};

/**
 * Alias for {@link Terrasoft#generateGUID}
 * @member Terrasoft.utils.guid
 * @method generateGUID
 * @inheritdoc Terrasoft#generateGUID
 */
Terrasoft.utils.guid.generateGUID = Terrasoft.generateGUID;

/**
 * Returns formatted GUID value.
 * @param {String} value GUID value string.
 * @param {String} format A single format specifier that indicates how to format the value of this GUID.
 * The format parameter can be "N", "D", "B", "P". If format is null or an empty string (""), "D" is used.
 * Example:
 *
 *     Terrasoft.formatGUID(value) returns 00000000-0000-0000-0000-000000000000
 *     Terrasoft.formatGUID(value, "D") returns 00000000-0000-0000-0000-000000000000
 *     Terrasoft.formatGUID(value, "N") returns 00000000000000000000000000000000
 *     Terrasoft.formatGUID(value, "B") returns {00000000-0000-0000-0000-000000000000}
 *     Terrasoft.formatGUID(value, "P") returns (00000000-0000-0000-0000-000000000000)
 *
 */
Terrasoft.formatGUID = function(value, format) {
	switch (format) {
		case "N":
			return value.replace(/-/g, "");
		case "B":
			return "{" + value + "}";
		case "P":
			return "(" + value + ")";
		case "D":
			return value;
		default:
			return value;
	}
};

/**
 * Checks whether string is empty GUID.
 * @param {String} value String representation of GUID.
 * @return {Boolean} Returns true if argument is empty GUID.
 */
Terrasoft.isEmptyGUID = function(value) {
	const reg = new RegExp("^(0){8}-(0){4}-(0){4}-(0){4}-(0){12}$");
	return reg.test(value);
};

/**
 * Alias for {@link Terrasoft.utils.guid#isEmptyGUID}
 * @member Terrasoft.utils.guid
 * @method isEmptyGUID
 * @inheritdoc Terrasoft#isEmptyGUID
 */
Terrasoft.utils.guid.isEmptyGUID = Terrasoft.isEmptyGUID;

/**
 * Checks whether string is GUID.
 * @param {String} value String representation of GUID.
 * @return {Boolean} Returns true if argument is GUID.
 */
Terrasoft.isGUID = function(value) {
	const uidRe = new RegExp("^[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}$", "i");
	return uidRe.test(value);
};

/**
 * Alias for {@link Terrasoft.utils.guid#isGUID}
 * @member Terrasoft.utils.guid
 * @method isGUID
 * @inheritdoc Terrasoft#isGUID
 */
Terrasoft.utils.guid.isGUID = Terrasoft.isGUID;

/**
 * Represents a conversion map of a byte to hexadecimal value.
 */
Terrasoft.utils.guid.ByteToHexMap = ["00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0a", "0b", "0c", "0d",
	"0e", "0f", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "1a", "1b", "1c", "1d", "1e", "1f", "20",
	"21", "22", "23", "24", "25", "26", "27", "28", "29", "2a", "2b", "2c", "2d", "2e", "2f", "30", "31", "32", "33",
	"34", "35", "36", "37", "38", "39", "3a", "3b", "3c", "3d", "3e", "3f", "40", "41", "42", "43", "44", "45", "46",
	"47", "48", "49", "4a", "4b", "4c", "4d", "4e", "4f", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59",
	"5a", "5b", "5c", "5d", "5e", "5f", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "6a", "6b", "6c",
	"6d", "6e", "6f", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "7a", "7b", "7c", "7d", "7e", "7f",
	"80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "8a", "8b", "8c", "8d", "8e", "8f", "90", "91", "92",
	"93", "94", "95", "96", "97", "98", "99", "9a", "9b", "9c", "9d", "9e", "9f", "a0", "a1", "a2", "a3", "a4", "a5",
	"a6", "a7", "a8", "a9", "aa", "ab", "ac", "ad", "ae", "af", "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7", "b8",
	"b9", "ba", "bb", "bc", "bd", "be", "bf", "c0", "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "ca", "cb",
	"cc", "cd", "ce", "cf", "d0", "d1", "d2", "d3", "d4", "d5", "d6", "d7", "d8", "d9", "da", "db", "dc", "dd", "de",
	"df", "e0", "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8", "e9", "ea", "eb", "ec", "ed", "ee", "ef", "f0", "f1",
	"f2", "f3", "f4", "f5", "f6", "f7", "f8", "f9", "fa", "fb", "fc", "fd", "fe", "ff"];

/**
 * Converts String that represents GUID to byte array.
 * @param {String} uId String that represents a GUID.
 * @return {Array} Returns bytes array.
 */
Terrasoft.convertGUIDToBytes = function(uId) {
	let index = 0;
	const buffer = [];
	uId.toLowerCase().replace(/[0-9a-f]{2}/g, function(hexValue) {
		if (index < 16) {
			buffer[index] = parseInt(hexValue, 16);
			index++;
		}
	});
	while (index < 16) {
		buffer[index++] = 0;
	}
	return buffer;
};

/**
 * Alias for {@link Terrasoft.utils.guid#convertGUIDToBytes}
 * @member Terrasoft.utils.guid
 * @method convertGUIDToBytes
 * @inheritdoc Terrasoft#convertGUIDToBytes
 */
Terrasoft.utils.guid.convertGUIDToBytes = Terrasoft.convertGUIDToBytes;

/**
 * Converts array of bytes to string that represents GUID.
 * @param {Array} bytes Bytes array.
 * @return {String} Returns string that represents generated GUID.
 */
Terrasoft.convertBytesToGUID = function(bytes) {
	const byteToHex = Terrasoft.utils.guid.ByteToHexMap;
	let i = 0;
	return byteToHex[bytes[i++]] + byteToHex[bytes[i++]] +
		byteToHex[bytes[i++]] + byteToHex[bytes[i++]] + '-' +
		byteToHex[bytes[i++]] + byteToHex[bytes[i++]] + '-' +
		byteToHex[bytes[i++]] + byteToHex[bytes[i++]] + '-' +
		byteToHex[bytes[i++]] + byteToHex[bytes[i++]] + '-' +
		byteToHex[bytes[i++]] + byteToHex[bytes[i++]] +
		byteToHex[bytes[i++]] + byteToHex[bytes[i++]] +
		byteToHex[bytes[i++]] + byteToHex[bytes[i++]];
};

/**
 * Alias for {@link Terrasoft.utils.guid#convertBytesToGUID}
 * @member Terrasoft.utils.guid
 * @method convertBytesToGUID
 * @inheritdoc Terrasoft#convertBytesToGUID
 */
Terrasoft.utils.guid.convertBytesToGUID = Terrasoft.convertBytesToGUID;

/**
 * Generates a deterministic GUID, which is based on XOR operation.
 * @param {String} sourceUId String that represents source GUID.
 * @param {String} anotherUId String that represents another GUID.
 * @return {String} Returns string that represents generated GUID.
 */
Terrasoft.xorToGUID = function(sourceUId, anotherUId) {
	const sourceUIdBytes = Terrasoft.convertGUIDToBytes(sourceUId);
	const anotherUIdBytes = Terrasoft.convertGUIDToBytes(anotherUId);
	Terrasoft.each(anotherUIdBytes, function(value, index) {
		sourceUIdBytes[index] ^= value;
	});
	return Terrasoft.convertBytesToGUID(sourceUIdBytes);
};

/**
 * Alias for {@link Terrasoft.utils.guid#xorToGUID}
 * @member Terrasoft.utils.guid
 * @method xorToGUID
 * @inheritdoc Terrasoft#xorToGUID
 */
Terrasoft.utils.guid.xorToGUID = Terrasoft.xorToGUID;