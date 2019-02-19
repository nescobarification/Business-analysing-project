// @flow
export interface Document {
	id: number,
	title: string,
	subtitle: string,
	cover: string,
	link: string,
	metadata: Array<MetaData>,
}

export interface MetaData {
	page: number,
	features: Array<MetaDataFeature>,
}

export interface MetaDataFeature {
	id: number,
	name: string,
}

export interface LibraryReducerState {
    list: Array<PdfInfo>,
    isLoading: boolean,
}

export interface PdfInfo {
    id: number,
    title: string,
    subtitle: string,
    cover: string,
	link: string,
	metadata: Array<MetaData>,
    pdfOption: PdfOption,
}

export interface PdfOption {
	path: string,
	isDownloaded: boolean,
	inError: boolean,
    errorMessage: string,
    openDate: Date,
	numberOfPages: number,
	initialPage: number,
	isHorizontal: boolean,
}

export interface PdfReducerState {
	pdfId: number,
	pdfPath: string,
	pdfTitle: string,
	isDownloading: boolean,
	inError: boolean,
	numberOfPages: number,
	initialPage: number,
	currentPage: number,
	isHorizontal: boolean,
	appState: string,
}

export interface MetricReducerState {
    pdfId: number,
	features: Array<MetricFeature>,
	option: MetricOption,
	sync: MetricSync,
}

export interface MetricReducerUpload {
    pdfId: string,
	features: Array<MetricFeature>,
}

export interface MetricFeature {
	featureId: number,
    date: Date,
    duration: number,
}

export interface MetricOption {
    featureIds: Array<number>,
    timerStarted: boolean,
    timeStart: Date,
}

export interface MetricSync {
	status: string,
	lastSyncDate: Date,
	errorMessage: string,
}

export interface SidebarReducerState {
	downloadOnlyMode: boolean,
}

export interface AuthReducerState {
	isLoggedIn: boolean,
	token: string,
}

export interface ReduxState {
    form: any,
    libraryReducer:LibraryReducerState,
	pdfReducer: PdfReducerState,
	metricReducer: MetricReducerState,
	sidebarReducer: SidebarReducerState,
	authReducer: AuthReducerState,
}

