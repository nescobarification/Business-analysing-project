// @flow
import React, { Component } from "react";
import { connect } from "react-redux";
import AuthLoading from "../../stories/screens/AuthLoading";
import { ReduxState } from "../../reducers/state-typed";

export interface Props {
	navigation: any,
	isLoggedIn: boolean,
}
export interface State { }
class AuthLoadingContainer extends Component<Props, State> {
	render() {
		return <AuthLoading {...this.props} />;
	}
}

const mapStateToProps = (state: ReduxState) => ({
	isLoggedIn: state.authReducer.isLoggedIn,
});
export default connect(mapStateToProps)(AuthLoadingContainer);
