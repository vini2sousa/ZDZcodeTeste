<template>
  <v-sheet id="formDelete" class="mx-auto" width="650">
    <h1>Excluir Cliente</h1>
    <v-form @submit.prevent="deleteCliente">
      <v-text-field
        v-model="cpfCliente"
        label="CPF do cliente"
      ></v-text-field>
      <v-btn class="mt-2" type="submit" block>Excluir</v-btn>
    </v-form>
  </v-sheet>
</template>

<script>
export default {
  data() {
    return {
      cpfCliente: ''
    };
  },
  methods: {
    async deleteCliente() {
      const chave = this.cpfCliente.trim();
      const url = `https://localhost:7248/Infos/${chave}`;
  
      try {
        const response = await fetch(url, {
          method: 'DELETE',
          headers: {
            'Content-Type': 'application/json'
          }
        });

        if (response.ok) {
          alert('Cliente excluído com sucesso!');
        } else {
          console.log('Erro na exclusão do cliente');
        }
      } catch (error) {
        console.error('Erro na requisição:');
      }
    }
  }
};
</script>

