// @flow
import produce from "immer";
import { LibraryReducerState, PdfReducerState, PdfInfo, PdfOption } from "../../reducers/state-typed";

const initialState = {
    list: [],
    isLoading: true,
};

const pdfOptionInitialState: PdfOption = {
    path: "",
    isDownloaded: false,
    inError: false,
    errorMessage: "",
    openDate: new Date(0),
    numberOfPages: -1,
    initialPage: 1,
    isHorizontal: false,
};

const libraryReducer = (state: LibraryReducerState = initialState, action: Function) =>
    produce(state, draft => {
        let pdfOption: PdfOption;
        switch (action.type) {
            case "FETCH_LIBRARY_SUCCESS":
                action.list.forEach((item: PdfInfo) => {
                    let pdfInfo = state.list.find(i => i.id === item.id);
                    if (pdfInfo === undefined) {
                        item.pdfOption = pdfOptionInitialState;
                        draft.list.push(item);
                    }

                    if (pdfInfo !== undefined && pdfInfo.pdfOption === undefined) {
                        draft.list.find(i => i.id === item.id).pdfOption = pdfOptionInitialState;
                    }
                });
                break;
            case "LIBRARY_IS_LOADING":
                draft.isLoading = action.isLoading;
                break;
            case "LIBRARY_SORTING":
                draft.list.sort(action.sortFunc);
                break;
            case "PDF_DOWNLOAD_SUCCESS":
                pdfOption = draft.list.find(i => i.id === action.id).pdfOption;
				pdfOption.path = action.path;
				pdfOption.isDownloaded = true;
                break;
            case "PDF_DOWNLOAD_FAILED":
                pdfOption = draft.list.find(i => i.id === action.id).pdfOption;
				pdfOption.path = "";
                pdfOption.isDownloaded = false;
                pdfOption.inError = true;
                pdfOption.errorMessage = action.message;
                break;
            case "PDF_DELETE_SUCCESS":
                pdfOption = draft.list.find(i => i.id === action.id).pdfOption;
				pdfOption.path = "";
				pdfOption.isDownloaded = false;
                break;
            case "PDF_EXIT":
                const pdfData: PdfReducerState = action.data;
                pdfOption = draft.list.find(i => i.id === pdfData.pdfId).pdfOption;
                pdfOption.initialPage = pdfData.currentPage;
                pdfOption.numberOfPages = pdfData.numberOfPages;
                pdfOption.isHorizontal = pdfData.isHorizontal;
                pdfOption.openDate = new Date();
                break;
            case "LOGOUT":
                draft.list = [];
                break;
        }
    });

export default libraryReducer;
