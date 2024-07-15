import Plugin from '@ckeditor/ckeditor5-core/src/plugin';
import ButtonView from '@ckeditor/ckeditor5-ui/src/button/buttonview';

export default class VariablePlugin extends Plugin {
    static get requires() {
        return ['Widget'];
    }

    init() {
        const editor = this.editor;
        const t = editor.t;

        // Add a button to the toolbar
        editor.ui.componentFactory.add('variable', locale => {
            const view = new ButtonView(locale);

            view.set({
                label: t('Insert Variable'),
                withText: true,
                tooltip: true
            });

            // Callback executed once the button is clicked
            view.on('execute', () => {
                const variableName = prompt('Variable name');
                if (variableName) {
                    editor.model.change(writer => {
                        const variableText = `{{${variableName}}}`;
                        const variableElement = writer.createText(variableText, { variable: true });
                        editor.model.insertContent(variableElement);
                    });
                }
            });

            return view;
        });

        // Define schema and conversion for variables
        editor.model.schema.extend('$text', { allowAttributes: 'variable' });
        editor.conversion.for('downcast').attributeToElement({
            model: 'variable',
            view: (modelAttributeValue, { writer }) => {
                return writer.createAttributeElement('span', {
                    class: 'variable'
                });
            }
        });
    }
}
