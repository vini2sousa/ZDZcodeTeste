import vuetify from "./plugins/vuetify";

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
 
  css: ["vuetify/styles/main.sass"],
  build: {
    transpile: ["vuetify"],
  },
  

});



