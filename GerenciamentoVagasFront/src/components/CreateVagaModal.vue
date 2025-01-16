<template>
    <div class="modal-overlay" >
      <div class="modal-content">
        <input 
          v-model="vaga.title" 
          class="editable-title" 
          type="text" 
          placeholder="Digite o título da vaga" />
  
        <select v-model="vaga.status" class="status-select">
          <option v-for="op of options" :value="op.value">{{ op.label }}</option>
        </select>
  
        <div class="actions">
          <button @click="$emit('create', vaga)">Criar</button>
          <button @click="close()">Fechar</button>
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  import { defineProps, defineEmits, ref } from 'vue';
  
  const vaga = ref({
    title: "",
    status: 0
  })
  
  const emit = defineEmits(['close', 'create']);

  const options = ref([
    {
        label: "ABERTA",
        value: 0
    },
    {
        label: "FINALIZADA",
        value: 1
    }
  ])
  
  function close() {
    emit('close');
  }
  </script>
  
  <style scoped>
  .modal-overlay {
    position: fixed;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: rgba(0, 0, 0, 0.5);
    display: flex;
    justify-content: center;
    align-items: center;
    z-index: 1000;
  }
  
  .modal-content {
    background: white;
    padding: 24px;
    border-radius: 16px;
    text-align: center;
    width: 50%;
    max-width: 500px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    color: black;
  }
  
  .editable-title {
    width: 100%;
    padding: 8px;
    margin-bottom: 16px;
    font-size: 1.2em;
    border: 1px solid #ccc;
    border-radius: 8px;
    outline: none;
  }
  
  .editable-title:focus {
    border-color: #007BFF;
  }
  
  .status-select {
    width: 100%;
    padding: 8px;
    margin-bottom: 16px;
    font-size: 1em;
    border: 1px solid #ccc;
    border-radius: 8px;
    outline: none;
  }
  
  .status-select:focus {
    border-color: #007BFF;
  }
  
  .actions {
    display: flex;
    justify-content: space-between;
    gap: 8px;
  }
  
  .actions button {
    padding: 8px 16px;
    border: none;
    border-radius: 8px;
    background-color: #007BFF;
    color: white;
    cursor: pointer;
    font-size: 1em;
    transition: background-color 0.3s;
  }
  
  .actions button:hover {
    background-color: #0056b3;
  }
  
  .actions button:active {
    background-color: #003f7f;
  }
  </style>
  