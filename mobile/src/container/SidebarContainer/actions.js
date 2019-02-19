// @flow
import { isPdfExist, deletePdfFile } from "../../utils/pdf";
import { deleteMetricStorage } from "../../metrics/api";
import { ReduxState } from "../../reducers/state-typed";

export function toggleDownloadOnlyMode() {
	return {
		type: "DOWNLOADONLY_MODE_UPDATE",
	};
}

export function logout() {
	return async (dispatch: Function, getState: () => ReduxState) => {
		//delete downloaded pdf file
		const pdfPaths = getState().libraryReducer.list
			.filter(i => i.pdfOption.isDownloaded)
			.map(i => i.pdfOption.path);

		for (let i = 0; i < pdfPaths.length; i++) {
			await deletePdf(pdfPaths[i]);
		}

		// TODO maybe try to upload the data before deleting everything
		await deleteMetricStorage();

		dispatch(logoutAction());
	};
}

async function deletePdf(pdfPath: string) {
	try {
		if (await isPdfExist(pdfPath)) {
			await deletePdfFile(pdfPath);
		}
	} catch (error) {
		console.log(error);
	}
}

function logoutAction() {
	return {
		type: "LOGOUT",
	};
}
