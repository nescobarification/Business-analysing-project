import { Dimensions, StyleSheet } from "react-native";
import variables from "../../../theme/variables/platform";
import color from "color";

const deviceHeight = Dimensions.get("window").height;

const styles: any = StyleSheet.create({
	container: {
		position: "absolute",
		top: 0,
		bottom: 0,
		left: 0,
		right: 0,
		backgroundColor: "#FBFAFA",
	},
	header: {
		height: 200,
		backgroundColor: color(variables.brandPrimary).lighten(0.5)
	},
	shadow: {
		flex: 1,
		width: undefined,
		height: undefined,
	},
	bg: {
		flex: 1,
		marginTop: deviceHeight / 1.75,
		paddingTop: 20,
		paddingLeft: 10,
		paddingRight: 10,
		paddingBottom: 30,
		bottom: 0,
	},
	input: {
		marginBottom: 20,
	},
	btn: {
		marginTop: 20,
		backgroundColor: "#032638"
	},
	thumbnail: {
		width: '60%',
		height: '40%' 
	},
	paddingTopSmall: {
		paddingTop: 20
	},
});
export default styles;
