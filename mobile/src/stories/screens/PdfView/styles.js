import color from "color";
import { StyleSheet, Dimensions } from "react-native";
import variables from "../../../theme/variables/platform";

const styles = StyleSheet.create({
    container: {
        flex: 1
    },
    containerPdf: {
        flex: 1,
        justifyContent: "flex-start",
        alignItems: "center",
        borderWidth: 0.5,
        borderColor: "#d6d7da",
    },
    pdf: {
        flex: 1,
        width: Dimensions.get("window").width,
        height: Dimensions.get("window").height - 90,
    },
    isDownloadingSpinner: {
        color: variables.brandInfo
    },
    floatingContainer: {
        position: "absolute",
        right: 0,
        left: 0,
        bottom: 25,
        zIndex: 1,
        justifyContent: "center",
        alignItems: "center"
    },
    floatingView: {
        width: 100,
        borderRadius:10,
        borderWidth: 1,
        borderColor: "rgba(192,192,192,0.3)",
        backgroundColor: "rgba(192,192,192,0.3)",
    },
    floatingText: {
        textAlign: "center",
        color: color("#c0c0c0").lighten(0.7)
    }
});

export default styles;
