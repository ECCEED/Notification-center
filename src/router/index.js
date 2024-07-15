import { createRouter, createWebHistory } from "vue-router";
import FormTemplate from "../components/FormTemplate.vue";
import ShowTemplates from "../views/ShowTemplates.vue";
import HomeAdmin from "../views/HomeAdmin.vue";

const routes = [
  {
    path: "/",
    name: "HomeAdmin",
    component: HomeAdmin,
  },
  {
    path: "/add-template",
    name: "AddTemplate",
    component: FormTemplate,
  },
  {
    path: "/show-templates",
    name: "ShowTemplates",
    component: ShowTemplates,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
