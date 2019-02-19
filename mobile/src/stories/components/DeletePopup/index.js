import { Alert } from "react-native";

export default function DeletePopup(isDownloaded:boolean, DeleteFunc: Function) {
    if (!isDownloaded) { return; } // Ignore if the document isn't downloaded.

    Alert.alert(
        "Remove the document",
        "Do you want to remove the downloaded document from this device?",
        [
            { text: "Cancel", style: "cancel" },
            { text: "Remove", style: "destructive", onPress: DeleteFunc },
        ],
        { cancelable: true }
    );
}
