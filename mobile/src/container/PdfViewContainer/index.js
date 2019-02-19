// @flow
import * as React from "react";
import { AppState } from "react-native";
import { connect } from "react-redux";
import { onLoadComplete, onPageChanged, onRotate, onExit, onAppStateChanged } from "./actions";
import PdfView from "../../stories/screens/PdfView";
import { PdfReducerState, ReduxState } from "../../reducers/state-typed";

export interface Props {
    navigation: any,
    data: PdfReducerState,
    onLoadComplete: Function,
    onPageChanged: Function,
    onRotate: Function,
    onExit: Function,
    onAppStateChanged: Function,
}
export interface State {}
class PdfViewContainer extends React.Component<Props, State> {

    componentDidMount() {
        AppState.addEventListener("change", this.props.onAppStateChanged);
    }

    componentWillUnmount() {
        this.props.onExit();
        AppState.removeEventListener("change", this.props.onAppStateChanged);
    }

	render() {
        return <PdfView {...this.props} />;
    }
}

function mapDispatchToProps(dispatch) {
	return {
        onLoadComplete: (numberOfPages, filePath) => dispatch(onLoadComplete(numberOfPages, filePath)),
        onPageChanged: (currentPage, numberOfPages) => dispatch(onPageChanged(currentPage, numberOfPages)),
        onRotate: () => dispatch(onRotate()),
        onExit: () => dispatch(onExit()),
        onAppStateChanged: (nextState) => dispatch(onAppStateChanged(nextState)),
	};
}

function mapStateToProps(state: ReduxState) {
    return {
        data: state.pdfReducer
    };
}
export default connect(mapStateToProps, mapDispatchToProps)(PdfViewContainer);
