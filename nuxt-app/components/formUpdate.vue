<template>
    <v-sheet id="formUpdate" class="mx-auto" width="650">
      <v-form @submit.prevent="updateCliente">
        <h1>Atualizar Cliente</h1>
        
        <v-text-field
          v-model="confirmaCPF"
          :rules="cpfRules"
          label="CPF do cliente"
        ></v-text-field>
  
        <v-text-field
          v-model="novoCPF"
          :rules="cpfRules"
          label="Novo CPF"
        ></v-text-field>
  
        <v-text-field
          v-model="novoNome"
          label="Novo nome"
        ></v-text-field>
  
        <v-text-field
          v-model="novoEmail"
          label="Novo email"
        ></v-text-field>
  
        <v-btn class="mt-2" type="submit" block>Atualizar</v-btn>
      </v-form>
    </v-sheet>
  </template>
  
  <script>
  export default {
    data() {
      return {
        confirmaCPF: '' ,
        
        novoCPF:'',
        
        novoNome:'',
       
        novoEmail:'',
        cpfRules: [
          value => value?.length === 11 || 'CPF deve conter 11 caracteres.'
        ]
      };
    },
    methods: {
      async updateCliente() {
        const cpfCliente = this.confirmaCPF.trim();
        const url = `https://localhost:7248/Infos/${cpfCliente}`;
  
        const dadosClienteFormatado = {
          CPF: this.novoCPF.trim(),
          NomeCompleto: this.novoNome.trim(),
          Email: this.novoEmail.trim()
        };
  
        try {
          const response = await fetch(url, {
            method: 'PUT',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(dadosClienteFormatado)
          });
  
  
          if (response.ok) {
            alert('Cliente atualizado com sucesso!');
          } else {
            alert(`Erro ao atualizar cliente!`);
          }
        } catch (error) {
          alert('Erro na requisição!');
        }
      }
    }
  };
  </script>
  
  