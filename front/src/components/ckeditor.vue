<template>
	<div>
		<div class="main-container">
			<div class="editor-container editor-container_classic-editor" ref="editorContainerElement">
				<div class="editor-container__editor">
					<div ref="editorElement">
						<ckeditor v-if="isLayoutReady" v-model="editorData" :editor="editor" :config="config" />
					</div>
				</div>
				<button id="save" @click="handleSave">Save</button>
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
	ImageStyle,
	ImageTextAlternative,
	ImageToolbar,
	ImageUpload,
	ImageResize,
	Italic,
	Link,
	LinkImage,
	List,
	ListProperties,
	Markdown,
	MediaEmbed,
	PageBreak,
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
	Undo
} from 'ckeditor5';

import 'ckeditor5/ckeditor5.css';
import axios from 'axios';

export default {
	name: 'app',
	data() {
		return {
			isLayoutReady: false,
			editorData: '',
			config: null, // CKEditor needs the DOM tree before calculating the configuration.
			editor: ClassicEditor
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
					'|',
					'heading',
					'|',
					'bold',
					'italic',
					'|',
					'pageBreak',
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
				ImageStyle,
				ImageTextAlternative,
				ImageToolbar,
				ImageUpload,
				ImageResize,
				Italic,
				Link,
				LinkImage,
				List,
				ListProperties,
				Markdown,
				MediaEmbed,
				PageBreak,
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
				Undo
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
				toolbar: ['toggleImageCaption', 'imageTextAlternative', '|', 'imageStyle:inline', 'imageStyle:wrapText', 'imageStyle:breakText']
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
			menuBar: {
				isVisible: true
			},
			placeholder: 'Type or paste your content here!',
			table: {
				contentToolbar: ['tableColumn', 'tableRow', 'mergeTableCells', 'tableProperties', 'tableCellProperties']
			}
		};

		this.isLayoutReady = true;
	},
	
	methods: {
		
		handleSave() {
			const data = this.editorData;
			// Save data to a server, localStorage, or any other necessary location
			console.log('Saved content:', data);
				// Example: Send a POST request to save the data (you need to configure axios or another HTTP library)
			 axios.post('https:localhost:7160/Template/Create', { input: data })
			 	.then(response => {
			 		console.log('Data saved successfully:', response);
			 	})
			 	.catch(error => {
			 		console.error('Error saving data:', error);
			 	});
		
			// You can implement your save logic here
		}
	}
};
</script>


