<template>
  <div>
    <nav class="navbar">
      <div class="navbar-content">
        <router-link to="/">Home</router-link>
        <router-link to="/show-templates">Show Templates</router-link>
      </div>
    </nav>
    <div class="template-form-container">
      <h1 class="title">Add Template</h1>
      <div class="template-form">
        <img
          src="https://i.imgur.com/xQImuuX.png"
          alt="NeoLedge Logo"
          class="logo"
        />
        <div class="form-group">
          <label for="template-name">Template Name</label>
          <input type="text" id="template-name" v-model="templateName" />
        </div>
        <div class="form-group">
          <label for="subject">Subject</label>
          <input type="text" id="subject" v-model="subject" />
        </div>
        <div class="form-group">
          <label for="description">Description</label>
          <ckeditor v-if="isLayoutReady" v-model="description" :editor="editor" :config="config" />
        </div>
        <div class="form-group">
          <label for="logo">Logo</label>
          <input type="file" id="logo" @change="onFileChange" />
        </div>
        <button @click="save">Save</button>
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

import CKEditor from '@ckeditor/ckeditor5-vue';
import 'ckeditor5/ckeditor5.css';
import axios from 'axios';

export default {
  components: {
    ckeditor: CKEditor.component
  },
  data() {
    return {
      isLayoutReady: false,
      templateName: "",
      subject: "",
      description: "",
      logo: null,
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
          { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
          { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
          { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
          { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
          { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
          { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
          { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' }
        ]
      },
      htmlSupport: {
        allow: [
          { name: /^.*$/, styles: true, attributes: true, classes: true }
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
            attributes: { download: 'file' }
          }
        }
      },
      list: {
        properties: { styles: true, startIndex: true, reversed: true }
      },
      menuBar: { isVisible: true },
      placeholder: 'Type or paste your content here!',
      table: {
        contentToolbar: ['tableColumn', 'tableRow', 'mergeTableCells', 'tableProperties', 'tableCellProperties']
      }
    };

    this.isLayoutReady = true;
  },
  methods: {
    onFileChange(e) {
      const file = e.target.files[0];
      this.logo = file;
    },
    save() {
      console.log("Template saved:", {
        templateName: this.templateName,
        subject: this.subject,
        description: this.description,
        logo: this.logo,
      });

      const data = this.description;

      if (this.containsSingleCurlyBraces(data)) {
        alert('Your text contains single curly braces `{` or `}`. Please use double curly braces `{{variable}}` for variables.');
        return;
      }

      const variables = this.extractVariables(data);
      console.log('Extracted variables:', variables);

      axios.post('https://localhost:7160/Template/Create', { input: data })
        .then(response => {
          console.log('Data saved successfully:', response);
        })
        .catch(error => {
          console.error('Error saving data:', error);
        });
    },
    extractVariables(content) {
      const regex = /{{(.*?)}}/g;
      let match;
      const variables = [];
      while ((match = regex.exec(content)) !== null) {
        variables.push(match[1]);
      }
      return variables;
    },
    containsSingleCurlyBraces(content) {
      const singleCurlyBracesRegex = /(^|[^{}]){([^{}]|$)|(^|[^{}])}([^{}]|$)/;
      return singleCurlyBracesRegex.test(content);
    }
  }
};
</script>

<style scoped>
.navbar {
  background-color: #0c6c8c;
  padding: 20px;
  width: 100%;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.navbar-content {
  display: flex;
  justify-content: flex-end;
  align-items: center;
  max-width: 1200px;
  margin: 0 auto;
}

.navbar-content a {
  color: white;
  text-decoration: none;
  padding: 10px 20px;
}

.navbar-content a:hover {
  background-color: #0056b3;
  border-radius: 4px;
}

.template-form-container {
  margin-top: 60px;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.title {
  font-size: 32px;
  font-weight: 400;
  margin-bottom: 20px;
  color: #0c6c8c;
  font-family: "Trebuchet MS", sans-serif;
}

.template-form {
  background-color: #ffffff;
  padding: 40px;
  border-radius: 10px;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  width: 800px;
  font-family: "Arial", sans-serif;
}

.form-group {
  margin-bottom: 20px;
}

.logo {
  display: block;
  margin: 0 auto 20px;
  width: 120px;
  height: auto;
}

input[type="text"],
textarea {
  width: calc(100% - 20px);
  padding: 10px;
  border: 1px solid #d1d5db;
  border-radius: 8px;
  font-size: 16px;
  margin-top: 8px;
}

textarea {
  height: 150px;
}

input[type="file"] {
  width: 100%;
  padding: 10px;
  border: 1px solid #d1d5db;
  border-radius: 8px;
  margin-top: 8px;
}

button {
  display: block;
  width: 100%;
  padding: 15px;
  background-color: #0c6c8c;
  color: white;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-size: 16px;
}

button:hover {
  background-color: #0056b3;
}

label {
  font-weight: bold;
  display: block;
  margin-bottom: 5px;
  color: #1f2937;
}
</style>
