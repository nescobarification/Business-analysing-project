// @flow
import React, { Component } from "react";
import { connect } from "react-redux";
import { ReduxState } from "../../reducers/state-typed";
import { toggleDownloadOnlyMode, logout } from "./actions";
import Sidebar from "../../stories/screens/Sidebar";

export interface Props {
	navigation: any,
	downloadOnlyMode: boolean,
	toggleDownloadOnlyMode: Function,
	logout: Function,
}
export interface State { }
class SidebarContainer extends Component<Props, State> {
	render() {
		return <Sidebar {...this.props} />;
	}
}

function mapDispatchToProps(dispatch) {
	return {
		toggleDownloadOnlyMode: () => dispatch(toggleDownloadOnlyMode()),
		logout: () => dispatch(logout()),
	};
}

const mapStateToProps = (state: ReduxState) => ({
	downloadOnlyMode: state.sidebarReducer.downloadOnlyMode,
});
export default connect(mapStateToProps, mapDispatchToProps)(SidebarContainer);
