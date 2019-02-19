// @flow
import * as React from "react";
import { connect } from "react-redux";
import BlankPage from "../../stories/screens/BlankPage";
import { ReduxState } from "../../reducers/state-typed";

export interface Props {
	navigation: any,
	token: string,
}
export interface State { }
class BlankPageContainer extends React.Component<Props, State> {
	render() {
		return <BlankPage {...this.props} />;
	}
}

function mapStateToProps(state: ReduxState) {
    return {
        token: state.authReducer.token
    };
}
export default connect(mapStateToProps)(BlankPageContainer);

