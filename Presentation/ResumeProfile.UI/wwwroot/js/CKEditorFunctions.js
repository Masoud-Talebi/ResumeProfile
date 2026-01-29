window.CKEditorFunctions = {
    editors: {},

    create: async function (elementId, dotnetRef) {
        return ClassicEditor
            .create(document.getElementById(elementId))
            .then(editor => {
                CKEditorFunctions.editors[elementId] = editor;

                editor.model.document.on("change:data", () => {
                    dotnetRef.invokeMethodAsync("OnCkeditorChange", editor.getData());
                });
            });
    },

    waitForReady: async function (elementId) {
        return new Promise(resolve => {
            let check = setInterval(() => {
                if (CKEditorFunctions.editors[elementId]) {
                    clearInterval(check);
                    resolve();
                }
            }, 10);
        });
    },

    setData: function (elementId, value) {
        let editor = CKEditorFunctions.editors[elementId];
        if (editor) {
            editor.setData(value);
        }
    }
};
