// @flow
import { combineReducers } from "redux";
import { reducer as formReducer } from "redux-form";
import { persistReducer } from "redux-persist";
import storage from "redux-persist/lib/storage"; // defaults to localStorage for web and AsyncStorage for react-native

import authReducer from "../container/LoginContainer/reducer";
import libraryReducer from "../container/LibraryContainer/reducer";
import pdfReducer from "../container/PdfViewContainer/reducer";
import sidebarReducer from "../container/SidebarContainer/reducer";
import metricReducer from "../metrics/reducer";

const persistConfig = {
    key: "root",
	storage,
	blacklist: ["form", "metricReducer"]
};

const rootReducer = combineReducers({
	form: formReducer,
	authReducer,
	libraryReducer,
	pdfReducer,
	metricReducer,
	sidebarReducer,
});

export default persistReducer(persistConfig, rootReducer);
