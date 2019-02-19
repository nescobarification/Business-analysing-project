import color from "color";
import { StyleSheet } from "react-native";
import variables from "../../../theme/variables/platform";

const styles = StyleSheet.create({
    container: {
        backgroundColor: color(variables.brandPrimary).desaturate(0.5)
    },
    body: {
        alignSelf: "stretch",
        backgroundColor: color(variables.brandPrimary).lighten(0.5).desaturate(0.5),
        marginLeft: 0,
        flexDirection: "column",
    },
    headerLogo: {
        flex: 1,
        marginTop: '10%',
        marginBottom: 5,
    },
    headerText: {
        color: "white",
        flex: 1,
        marginTop: 5,
        marginBottom: 5,
    },
    listItemIcon: {
        color: "white",
    },
    listItemText: {
        color: "white"
    },
    btnLogout: {
        position: "absolute",
        left: 0,
        right: 0
    },
});

export default styles;
