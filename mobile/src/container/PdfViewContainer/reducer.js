// @flow
import produce from "immer";
import { PdfReducerState, PdfOption } from "../../reducers/state-typed";

const initialState = {
	pdfId: -1,
	pdfPath: "",
	pdfTitle: "",
	isDownloading: true,
	inError: false,
	numberOfPages: 0,
	initialPage: 1,
	currentPage: 1,
	isHorizontal: true,
	appState: "active",
};

const setPdfOption = (draft: any, pdfOption: PdfOption) => {
	draft.inError = pdfOption.inError;
	draft.numberOfPages = pdfOption.numberOfPages;
	draft.initialPage = pdfOption.initialPage;
	draft.isHorizontal = pdfOption.isHorizontal;
};

const pdfReducer = (state: PdfReducerState = initialState, action: Function) =>
    produce(state, draft => {
        switch (action.type) {
			case "PDF_EXIST":
			case "PDF_DOWNLOAD_SUCCESS":
				draft.pdfId = action.id;
				draft.pdfPath = action.path;
				draft.pdfTitle = action.title;
				draft.isDownloading = false;
				setPdfOption(draft, action.pdfOption);
				break;
			case "PDF_IS_DOWNLOADING":
				draft.pdfId = action.id;
				draft.pdfPath = "";
				draft.pdfTitle = "Downloading";
				draft.isDownloading = true;
				break;
			case "PDF_DOWNLOAD_FAILED":
			case "PDF_READ_ERROR":
				draft.pdfTitle = action.message;
				draft.inError = true;
				draft.isDownloading = false;
				break;
            case "PDF_LOADED":
				draft.numberOfPages = action.data.numberOfPages;
                break;
            case "PDF_PAGE_CHANGED":
				draft.currentPage = action.data.currentPage;
                break;
            case "PDF_ROTATE":
				draft.isHorizontal = !state.isHorizontal;
				break;
			case "PDF_EXIT":
				draft.pdfId = -1;
				draft.pdfPath = "";
				draft.pdfTitle = "";
				break;
			case "APPSTATE_CHANGED":
				draft.appState = action.nextState;
				break;
        }
    });

export default pdfReducer;
