// @flow
import * as React from "react";
import { Text, Container, View, Button, Content, Spinner, Icon } from "native-base";
import BackButton from "../../components/BackButton";
import HeaderNav from "../../components/HeaderNav";
import Pdf from "react-native-pdf";
import { PdfReducerState } from "../../../reducers/state-typed";
import styles from "./styles";

export interface Props {
    navigation: any,
    data: PdfReducerState,
    onPageChanged: Function,
    onLoadComplete: Function,
    onRotate: Function,
}
export interface State { }
class PdfView extends React.Component<Props, State> {
    render() {
        const { navigation, onRotate, data } = this.props;
        const { pdfTitle } = data;

        return (
            <Container style={styles.container}>
                <HeaderNav navigation={navigation} button={BackButton} title={pdfTitle}>
                    <Button primary onPress={onRotate}>
                        <Text>Rotate</Text>
                    </Button>
                </HeaderNav>
                { this._renderPDFSection() }
            </Container>
        );
    }

    _renderPDFSection() {
        const { onLoadComplete, onPageChanged, data } = this.props;
        const { pdfPath, isDownloading, numberOfPages, initialPage, currentPage, isHorizontal } = data;

        let PDFSection: Content;

        // TODO refactor this and error handling

        if (isDownloading) {
            PDFSection =
                <Content style={styles.container}>
                    <Spinner color={styles.isDownloadingSpinner.color} />
                </Content>;
        } else {
            PDFSection =
                <Content style={styles.container}>
                    <View style={styles.floatingContainer}>
                        <View style={styles.floatingView}>
                            <Text style={styles.floatingText}>Page {currentPage} de {numberOfPages}</Text>
                        </View>
                    </View>
                    <View style={styles.containerPdf}>
                        <Pdf
                            source={{uri: pdfPath}}
                            onLoadComplete={onLoadComplete}
                            onPageChanged={onPageChanged}
                            horizontal={isHorizontal}
                            style={styles.pdf}
                            page={initialPage} />
                    </View>
                </Content>;
        }

        return PDFSection;
    }
}

export default PdfView;
