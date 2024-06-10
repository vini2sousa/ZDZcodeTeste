<template>
  <v-toolbar title="ZDZCode">
    <v-container>
      
      <v-row align="center" justify="start">
        <v-col class="ml-3" cols="auto">
          <v-btn density="compact" @click="scrollTo('formPF')">Cadastrar Cliente</v-btn>
        </v-col>


        <v-col class="ml-3" cols="auto">
          <v-btn density="default" @click="scrollTo('formDelete')">Excluir Cliente</v-btn>
        </v-col>

       
        <v-col class="ml-3" cols="auto">
          <v-btn density="default" @click="scrollTo('formUpdate')">Atualizar Cliente</v-btn>
        </v-col>
        
      </v-row>
    </v-container>
  </v-toolbar>
</template>

<script>
export default {
  methods: {
    scrollTo(formId) {
      const form = document.getElementById(formId);
      if (form) {
        form.scrollIntoView({ behavior: 'smooth' });
      }
    }
  }
};
</script>
