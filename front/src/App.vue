<template>
  <div>
    NEOLEDGE
  </div>
  <div id="app">
      <ckeditor :editor="editor" v-model="editorData" :config="editorConfig"></ckeditor>
  </div>
</template>

<script>

import { ClassicEditor, Bold, Essentials, Italic, Paragraph, Undo } from 'ckeditor5';

import CKEditor from '@ckeditor/ckeditor5-vue';

import 'ckeditor5/ckeditor5.css';

import 'ckeditor5-premium-features/ckeditor5-premium-features.css';

export default {
  name: 'app',
  components: {
      ckeditor: CKEditor.component
  },
  data() {
      return {
          editor: ClassicEditor,
          editorData: '<p>Hello!</p>',
          editorConfig: {
            plugins: [ Bold, Essentials, Italic, Paragraph, Undo ],
            toolbar: [ 'undo', 'redo', '|', 'bold', 'italic' ]
          }
      };
  }
}
</script>
