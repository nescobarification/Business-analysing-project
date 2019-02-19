// @flow
import RNFetchBlob from "react-native-fetch-blob";

export async function downloadPdf(link: string, path: string) {
	try {
		return await RNFetchBlob.config({
			// response data will be saved to this path if it has access right.
			path
		})
		.fetch("GET", link);
	} catch (error) {
		throw ("Error while downloading file.");
	}
}

export async function isPdfExist(path: string) {
	try {
		return await RNFetchBlob.fs.exists(path);
	} catch (error) {
		throw ("Error while verifying if file exists.");
	}
}

export async function deletePdfFile(path: string) {
	try {
		return await RNFetchBlob.fs.unlink(path);
	} catch (error) {
		throw ("Error while deleting the file.");
	}
}

export function filePath(name: string, extension: string) {
	// Remove space
	name = name.replace(/\s/g, "");

	const searchPath = RNFetchBlob.fs.dirs.DocumentDir + "/" + name + "." + extension;

	return searchPath;
}