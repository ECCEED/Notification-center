import './assets/style.css'

import CKEditor from '@ckeditor/ckeditor5-vue'

import { createApp } from 'vue'
import App from './App.vue'


const app = createApp(App)

app.use(CKEditor)
app.mount('#app')
