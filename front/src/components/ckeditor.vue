<template>
	<div>
		<div class="main-container">
			<div class="editor-container editor-container_classic-editor" ref="editorContainerElement">
				<div class="editor-container__editor">
					<div ref="editorElement">
						<ckeditor v-if="isLayoutReady" v-model="config.initialData" :editor="editor" :config="config" />
                        <button id="save" @click="handleSave">Save</button>
					</div>
				</div>
			</div>
			
		
		</div>
	</div>
</template>

<script>
import {
	ClassicEditor,
	AccessibilityHelp,
	Autoformat,
	Autosave,
	Bold,
	Essentials,
	FindAndReplace,
	FullPage,
	GeneralHtmlSupport,
	Heading,
	HtmlComment,
	HtmlEmbed,
	ImageBlock,
	ImageCaption,
	ImageInline,
	ImageInsert,
	ImageInsertViaUrl,
	ImageResize,
	ImageStyle,
	ImageTextAlternative,
	ImageToolbar,
	ImageUpload,
	Italic,
	Link,
	LinkImage,
	List,
	ListProperties,
	Markdown,
	MediaEmbed,
	Mention,
	Paragraph,
	PasteFromMarkdownExperimental,
	PasteFromOffice,
	SelectAll,
	ShowBlocks,
	SimpleUploadAdapter,
	SourceEditing,
	Table,
	TableCaption,
	TableCellProperties,
	TableColumnResize,
	TableProperties,
	TableToolbar,
	TextPartLanguage,
	TextTransformation,
	Title,
	TodoList,
	Undo,
	PendingActions
} from 'ckeditor5';

import 'ckeditor5/ckeditor5.css';

export default {
	name: 'app',
	data() {
		return {
			isLayoutReady: false,
			config: null,
			editor: ClassicEditor,
			isDirty: false
		};
	},
	mounted() {
		this.config = {
			toolbar: {
				items: [
					'undo',
					'redo',
					'|',
					'sourceEditing',
					'showBlocks',
					'findAndReplace',
					'selectAll',
					'textPartLanguage',
					'|',
					'heading',
					'|',
					'bold',
					'italic',
					'|',
					'link',
					'insertImage',
					'insertImageViaUrl',
					'mediaEmbed',
					'insertTable',
					'htmlEmbed',
					'|',
					'bulletedList',
					'numberedList',
					'todoList',
					'|',
					'accessibilityHelp'
				],
				shouldNotGroupWhenFull: false
			},
			plugins: [
				AccessibilityHelp,
				Autoformat,
				Autosave,
				Bold,
				Essentials,
				FindAndReplace,
				FullPage,
				GeneralHtmlSupport,
				Heading,
				HtmlComment,
				HtmlEmbed,
				ImageBlock,
				ImageCaption,
				ImageInline,
				ImageInsert,
				ImageInsertViaUrl,
				ImageResize,
				ImageStyle,
				ImageTextAlternative,
				ImageToolbar,
				ImageUpload,
				Italic,
				Link,
				LinkImage,
				List,
				ListProperties,
				Markdown,
				MediaEmbed,
				Mention,
				Paragraph,
				PasteFromMarkdownExperimental,
				PasteFromOffice,
				SelectAll,
				ShowBlocks,
				SimpleUploadAdapter,
				SourceEditing,
				Table,
				TableCaption,
				TableCellProperties,
				TableColumnResize,
				TableProperties,
				TableToolbar,
				TextPartLanguage,
				TextTransformation,
				Title,
				TodoList,
				Undo,
				PendingActions
			],
			heading: {
				options: [
					{
						model: 'paragraph',
						title: 'Paragraph',
						class: 'ck-heading_paragraph'
					},
					{
						model: 'heading1',
						view: 'h1',
						title: 'Heading 1',
						class: 'ck-heading_heading1'
					},
					{
						model: 'heading2',
						view: 'h2',
						title: 'Heading 2',
						class: 'ck-heading_heading2'
					},
					{
						model: 'heading3',
						view: 'h3',
						title: 'Heading 3',
						class: 'ck-heading_heading3'
					},
					{
						model: 'heading4',
						view: 'h4',
						title: 'Heading 4',
						class: 'ck-heading_heading4'
					},
					{
						model: 'heading5',
						view: 'h5',
						title: 'Heading 5',
						class: 'ck-heading_heading5'
					},
					{
						model: 'heading6',
						view: 'h6',
						title: 'Heading 6',
						class: 'ck-heading_heading6'
					}
				]
			},
			htmlSupport: {
				allow: [
					{
						name: /^.*$/,
						styles: true,
						attributes: true,
						classes: true
					}
				]
			},
			image: {
				toolbar: [
					'toggleImageCaption',
					'imageTextAlternative',
					'|',
					'imageStyle:inline',
					'imageStyle:wrapText',
					'imageStyle:breakText',
					'|',
					'resizeImage'
				]
			},
			link: {
				addTargetToExternalLinks: true,
				defaultProtocol: 'https://',
				decorators: {
					toggleDownloadable: {
						mode: 'manual',
						label: 'Downloadable',
						attributes: {
							download: 'file'
						}
					}
				}
			},
			list: {
				properties: {
					styles: true,
					startIndex: true,
					reversed: true
				}
			},
			mention: {
				feeds: [
					{
						marker: '@',
						feed: [
							/* See: https://ckeditor.com/docs/ckeditor5/latest/features/mentions.html */
						]
					}
				]
			},
			menuBar: {
				isVisible: true
			},
			table: {
				contentToolbar: ['tableColumn', 'tableRow', 'mergeTableCells', 'tableProperties', 'tableCellProperties']
			}
		};

		this.isLayoutReady = true;

		this.$nextTick(() => {
			const editor = this.$refs.editorElement.editorInstance;

			editor.model.document.on('change:data', () => {
				this.isDirty = true;
				this.updateStatus(editor);
			});

			editor.plugins.get('PendingActions').on('change:hasAny', () => this.updateStatus(editor));

			window.addEventListener('beforeunload', (evt) => {
				if (editor.plugins.get('PendingActions').hasAny) {
					evt.preventDefault();
				}
			});
		});
	},
	methods: {
		async handleSave(evt) {
			const editor = this.$refs.editorElement.editorInstance;
			const data = editor.getData();
			const pendingActions = editor.plugins.get('PendingActions');
			const action = pendingActions.add('Saving changes');

			evt.preventDefault();

			try {
				const response = await fetch('/your-server-endpoint', {
					method: 'POST',
					headers: {
						'Content-Type': 'application/json'
					},
					body: JSON.stringify({ content: data })
				});

				if (!response.ok) {
					throw new Error('Network response was not ok');
				}

				pendingActions.remove(action);

				if (data === editor.getData()) {
					this.isDirty = false;
				}

				this.updateStatus(editor);
			} catch (error) {
				console.error('There was a problem with the save operation:', error);
				pendingActions.remove(action);
			}
		},
		updateStatus(editor) {
			const saveButton = document.querySelector('#save');

			if (this.isDirty) {
				saveButton.classList.add('active');
			} else {
				saveButton.classList.remove('active');
			}

			if (editor.plugins.get('PendingActions').hasAny) {
				saveButton.classList.add('saving');
			} else {
				saveButton.classList.remove('saving');
			}
		}
	}
};
</script>
