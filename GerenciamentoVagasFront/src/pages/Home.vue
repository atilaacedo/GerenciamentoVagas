<template>
  <div class="main">
    <header>
      <h1 class="main-title">Gerenciamento de vagas</h1>
    </header>

    <main class="main">
      <div class="filter-container">
        <button class="btn-create" @click="openModalCreateVaga()">Nova Vaga</button>
      </div>
      <div class="vagas-container">
        <div v-for="(vaga, i) in viewVagas" :key="i" class="v-card" @click="openModalVaga(vaga)">

          <h3>{{ vaga.title }}</h3>

          <div :class="['status-indicator', vaga.status === 'ABERTA' ? 'open' : 'closed']">
            {{ vaga.status }}
          </div>
        </div>

      </div>
    </main>
    <VagaModal v-if="isOpenModalVaga" :vaga="selectedVaga" @close="closeModalVaga" @edit="editVaga"
      @delete="deleteVaga" />

    <CreateVagaModal v-if="isOpenModalCreateVaga" @create="createVaga" @close="closeModalCreateVaga" />
  </div>
</template>

<script setup>

import { ref, onMounted } from 'vue';
import VagaModal from '@/components/VagaModal.vue';
import CreateVagaModal from '@/components/CreateVagaModal.vue';

const vagas = ref([]);

const viewVagas = ref([]);

const isOpenModalVaga = ref(false);
const isOpenModalCreateVaga = ref(false);
const selectedVaga = ref(null);

const openModalVaga = (vaga) => {
  const targetVaga = vagas.value.find((v) => v.id === vaga.id);
  selectedVaga.value = targetVaga;
  isOpenModalVaga.value = true;
}

const closeModalVaga = () => {
  isOpenModalVaga.value = false;
  selectedVaga.value = null;
}

const openModalCreateVaga = () => {
  isOpenModalCreateVaga.value = true;
}

const closeModalCreateVaga = () => {
  isOpenModalCreateVaga.value = false;
}

const processData = (prom) => {
  vagas.value = prom.data;

  viewVagas.value = vagas.value.map((vaga) => {
    const v = { ...vaga };
    if (v.title.length > 30) {
      v.title = vaga.title.substring(0, 30) + '...';
    }

    v.status = v.status === 0 ? 'ABERTA' : 'FINALIZADA'

    return v
  });
}

const editVaga = async () => {
  try {
    const payload = {
      idVaga: selectedVaga.value.id,
      title: selectedVaga.value.title,
      status: selectedVaga.value.status
    }
    const response = await fetch(`https://localhost:7154/api/Vaga/Edit`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(payload)
    });

    const prom = await response.json();

    processData(prom);
    closeModalVaga();

  } catch (error) {
    console.log(error)
  }
}

const deleteVaga = async () => {
  try {

    const response = await fetch(`https://localhost:7154/api/Vaga/Delete?idVaga=${selectedVaga.value.id}`, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json"
      }
    });
    const prom = await response.json();

    processData(prom);

    closeModalVaga();
  } catch (error) {

  }
}

const createVaga = async (vaga) => {
  try {
    const payload = {
      title: vaga.title,
      status: vaga.status
    }
    const response = await fetch(`https://localhost:7154/api/Vaga/Create`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(payload)
    });

    const prom = await response.json();
    processData(prom);
    closeModalCreateVaga();
  } catch (error) {

  }
}


const getVagas = async () => {

  try {

    const response = await fetch(`https://localhost:7154/api/Vaga/List`, {
      method: "GET",
      headers: {
        "content-type": "application/json"
      }
    })

    const prom = await response.json()

    processData(prom);
  } catch (error) {
    console.log(error);
  }


}

onMounted(() => {
  getVagas();
})

</script>

<style scoped>
.main-title {
  display: flex;
  justify-content: center;
  margin-top: 5vh;
}

main {
  margin-top: 5vh;
  display: flex;
  align-items: center;
  flex-direction: column;
}

.btn-create {
  padding: 8px 16px;
  border: none;
  border-radius: 8px;
  background-color: #007BFF;
  color: white;
  cursor: pointer;
  font-size: 1em;
  transition: background-color 0.3s;
}

.btn-create:hover {
  background-color: #0056b3;
}

.vagas-container {
  display: grid;
  grid-template-columns: repeat(5, 1fr);
  gap: 16px;
  width: 70%;
  justify-items: center;
  align-items: center;
  margin-top: 10px;
}

.v-card {
  width: 200px;
  height: 15vh;
  border: 1px solid #ccc;
  border-radius: 8px;
  padding: 8px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: center;
  cursor: pointer;
  box-shadow: 0 2px 4px rgba(195, 188, 188, 0.89);
  transition: box-shadow 0.3s;
}

.v-card:hover {
  box-shadow: 0 4px 8px rgb(246, 246, 246);
}


.status-indicator.open {
  color: green;
}

.status-indicator.closed {
  color: red;
}
</style>