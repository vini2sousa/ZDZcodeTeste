<template>
  <v-sheet id="formPF" class="mx-auto" width="650">
    <v-form fast-fail @submit.prevent="submit">
      <h1 class="center">Cadastrar Cliente</h1>
      
      <v-text-field
        v-model="infosPF.cpf"
        :rules="cpfRules"
        label="CPF"
      ></v-text-field>
      
      <v-text-field
        v-model="infosPF.NomeCompleto"
        label="Nome Completo"
      ></v-text-field>
     
      <v-text-field
        v-model="infosPF.Email"
        label="Email"
      ></v-text-field>


      <v-btn class="mt-2" block @click="submit">Cadastrar</v-btn>

      <v-data-table
        :headers="headers"
        :items="informacoes"
        :items-per-page="5"
        class="elevation-1"
      ></v-data-table>
    </v-form>
  </v-sheet>
</template>

<script>
export default {
  data() {
    return {
      infosPF: {
        cpf: '',
        NomeCompleto: '',
        Email: '',
      },
      cpfRules: [
        value => value?.length === 11 || 'CPF deve conter 11 caracteres.'
      ],
      headers: [
        {
          text: "Nome",
          align: "start",
          sortable: false,
          value: "NomeCompleto",
        },
        { text: "Email", value: "Email" },
      ],
      informacoes: [],
    };
  },
  mounted() {
    this.informacoes.push({ NomeCompleto: "Cliente", Email: "Email" });
  },
  methods: {
    async submit() {
      try {
        await fetch("https://localhost:7248/Infos", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(this.infosPF),
        });

       
        this.informacoes.push({
          NomeCompleto: this.infosPF.NomeCompleto,
          Email: this.infosPF.Email,
        });

        
        this.infosPF.cpf = '';
        this.infosPF.NomeCompleto = '';
        this.infosPF.Email = '';


      } catch (error) {
        alert('Erro ao cadastrar cliente!');
      }
    },
  },
};
</script>
