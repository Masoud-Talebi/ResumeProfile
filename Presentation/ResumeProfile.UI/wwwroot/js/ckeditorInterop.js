window.CKEditorFunctions = {
    editors: {},

    create: function (elementId, dotnetHelper) {
        ClassicEditor
            .create(document.getElementById(elementId), {
                toolbar: [
                    'heading', '|',
                    'bold', 'italic', 'underline', '|',
                    'link', 'blockQuote', 'codeBlock', '|',
                    'bulletedList', 'numberedList', '|',
                    'insertTable', '|',
                ]
            })
            .then(editor => {
                this.editors[elementId] = editor;

                editor.model.document.on('change:data', () => {
                    dotnetHelper.invokeMethodAsync('OnCkeditorChange', editor.getData());
                });
            })
            .catch(error => console.error(error));
    },

    setData: function (elementId, data) {
        if (this.editors[elementId]) {
            this.editors[elementId].setData(data);
        }
    },

    getData: function (elementId) {
        return this.editors[elementId] ? this.editors[elementId].getData() : "";
    }
};
