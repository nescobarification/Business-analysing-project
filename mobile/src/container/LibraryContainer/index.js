// @flow
import * as React from "react";
import { connect } from "react-redux";
import Library from "../../stories/screens/Library";
import DeletePopup from "../../stories/components/DeletePopup";
import { fetchList, sortList, openPdf, deletePdf } from "./actions";
import { ReduxState, PdfInfo } from "../../reducers/state-typed";

export interface Props {
	navigation: any,
	list: Array<PdfInfo>,
	isLoading: boolean,
	fetchList: Function,
	sortList: Function,
	onPressItem: Function,
	onLongPressItem: Function,
	downloadOnlyMode: boolean,
}
export interface State {}
class LibraryContainer extends React.Component<Props, State> {
	componentDidMount() {
		// Fetch to the server to download the data.json
		this.props.fetchList("url hardcoder");
	}

	render() {
		return <Library {...this.props}
			onRefresh={() => this.props.fetchList(this.props.list)}/>;
	}
}

function mapDispatchToProps(dispatch) {
	return {
		fetchList: (url) => dispatch(fetchList(url)),
		sortList: (index) => dispatch(sortList(index)),
		onPressItem: (id) => dispatch(openPdf(id)),
		onLongPressItem: (id, isDownloaded) => DeletePopup(isDownloaded, () => dispatch(deletePdf(id))),
	};
}

const mapStateToProps = (state: ReduxState) => ({
	list: state.libraryReducer.list,
	isLoading: state.libraryReducer.isLoading,
	downloadOnlyMode: state.sidebarReducer.downloadOnlyMode,
});
export default connect(mapStateToProps, mapDispatchToProps)(LibraryContainer);
