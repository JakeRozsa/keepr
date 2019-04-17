<template>
  <!-- Modal -->
  <div class="modal fade AddKeep col-12" id="VaultModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
    aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Add a new Keep!</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form class="row" @submit.prevent='createVault()'>
            <input type="text" v-model="newVault.name" class="form-control field"
              placeholder="Enter desired Vault name here">
            <br>
            <input type="text" v-model="newVault.description" class="form-control field"
              placeholder="Enter Vault description here">
            <br>
            <div>
              <button type="submit" class="btn btn-primary">Submit</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'AddVault',
    data() {
      return {
        newVault: {
          name: '',
          description: '',
          UserId: this.$store.state.user.id
        }
      }
    },
    computed: {},
    methods: {
      createVault() {
        this.$store.dispatch('CreateVault', this.newVault)
      }
    },
    components: {}
  }
</script>


<style scoped>
</style>