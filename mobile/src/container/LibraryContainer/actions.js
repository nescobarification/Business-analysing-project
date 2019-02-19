// @flow
import { downloadPdf, isPdfExist, deletePdfFile, filePath } from "../../utils/pdf";
import { ReduxState, PdfOption, Document, PdfInfo } from "../../reducers/state-typed";
import { URL } from "react-native-dotenv";
import datas from "./data";

export function fetchList(url: string) {
	return async (dispatch: Function, getState: () => ReduxState) => {
		try {
			dispatch(listIsLoading(true));

			console.log(URL + "/api/content/availableContentForUser");
			const token = getState().authReducer.token;

			const res = await fetch(URL + "/api/content/availableContentForUser", {
				method: "POST",
				headers: {
					"Authorization": "Bearer " + token
				},
			});

			if (res.ok) {
				const json = await res.json();
				const availableData = datas.filter(x => json.pdfIds.includes(x.id));

				setTimeout(() => {
					dispatch(fetchListSuccess(availableData));
					dispatch(listIsLoading(false));
				}, 1000);
			} else {
				// We will just show all the pdf availables 
				// for testing purpose.
				setTimeout(() => {
					dispatch(fetchListSuccess(datas));
					dispatch(listIsLoading(false));
				}, 1000);
			}
		} catch (e) {
			console.log(e);
		}
	};
}

export function sortList(sortIndex: number) {
	return (dispatch: Function) => {
		dispatch(listIsLoading(true));
		setTimeout(() => {
			switch (sortIndex) {
				case 0: // by date
					dispatch(sortLibrary(sortByRecent));
					break;
				case 1: // by title
					dispatch(sortLibrary(sortByTitle));
					break;
			}
			dispatch(listIsLoading(false));
		}, 100);
	};
}

function listIsLoading(bool: boolean) {
	return {
		type: "LIBRARY_IS_LOADING",
		isLoading: bool,
	};
}

function fetchListSuccess(list: Array<Document>) {
	return {
		type: "FETCH_LIBRARY_SUCCESS",
		list,
	};
}

function sortLibrary(sortFunc: Function) {
	return {
		type: "LIBRARY_SORTING",
		sortFunc
	};
}

function sortByRecent(a: PdfInfo, b: PdfInfo) {
	return new Date(a.pdfOption.openDate) < new Date(b.pdfOption.openDate);
}

function sortByTitle(a: Document, b: Document) {
	return a.title.localeCompare(b.title);
}

export function deletePdf(id: number) {
	return async (dispatch: Function, getState: () => ReduxState) => {
		const pdfPath = getState().libraryReducer.list.find(i => i.id === id).pdfOption.path;

		try {
			if (await isPdfExist(pdfPath)) {
				try {
					await deletePdfFile(pdfPath);
					dispatch(pdfDeleteSuccess(id));
				} catch (error) {
					dispatch(pdfDeleteFailed(error));
				}
			}
		} catch (error) {
			dispatch(pdfReadError(error));
		}
	};
}

export function openPdf(id: number) {
	return async (dispatch: Function, getState: () => ReduxState) => {
		const pdf = getState().libraryReducer.list.find(i => i.id === id);
		const title = pdf.title;
		const pdfOption = pdf.pdfOption;
		const pdfPath = filePath(title, "pdf");

		try {
			if (await isPdfExist(pdfPath)) {
				dispatch(pdfExist(id, pdfPath, title, pdfOption));
			} else {
				dispatch(pdfIsDownloading(id));
				try {
					const res = await downloadPdf(pdf.link, pdfPath);
					dispatch(pdfDownloadSuccess(id, res.path(), title, pdfOption));
				} catch (error) {
					dispatch(pdfDownloadFailed(id, error));
				}
			}
		} catch (error) {
			dispatch(pdfReadError(error));
		}
	};
}

function pdfExist(id: number, path: string, title: string, pdfOption: PdfOption) {
	return {
		type: "PDF_EXIST",
		id,
		path,
		title,
		pdfOption,
	};
}

function pdfReadError(message: string) {
	return {
		type: "PDF_READ_ERROR",
		message,
	};
}

function pdfIsDownloading(id: number) {
	return {
		type: "PDF_IS_DOWNLOADING",
		id,
	};
}

function pdfDownloadSuccess(id: number, path: string, title: string, pdfOption: PdfOption) {
	return {
		type: "PDF_DOWNLOAD_SUCCESS",
		id,
		path,
		title,
		pdfOption,
	};
}

function pdfDownloadFailed(id: number, message: string) {
	return {
		type: "PDF_DOWNLOAD_FAILED",
		id,
		message,
	};
}

function pdfDeleteSuccess(id: number) {
	return {
		type: "PDF_DELETE_SUCCESS",
		id,
	};
}

function pdfDeleteFailed(message: string) {
	return {
		type: "PDF_DELETE_FAILED",
		message,
	};
}
