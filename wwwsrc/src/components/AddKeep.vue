<template>
  <!-- Modal -->
  <div class="modal fade AddKeep col-12" id="exampleModal" tabindex="-1" role="dialog"
    aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Add a new Keep!</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form class="row" @submit.prevent='createKeep()'>
            <input type="text" v-model="newKeep.name" class="form-control field"
              placeholder="Enter desired keep name here">
            <br>
            <input type="text" v-model="newKeep.description" class="form-control field"
              placeholder="Enter keep description here">
            <br>
            <input type="text" v-model="newKeep.img" class="form-control field" placeholder="Enter Image here">
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
    name: 'AddKeep',
    data() {
      return {
        newKeep: {
          name: '',
          description: '',
          img: '',
          UserId: this.$store.state.user.id
        }
      }
    },
    computed: {
    },
    methods: {
      createKeep() {
        debugger
        this.$store.dispatch('CreateKeep', this.newKeep)
      }
    },
    components: {}
  }
</script>


<style scoped>
  .field {
    width: 20vw;
  }

  @media only screen and (max-width: 450px) {
    .field {
      width: 76vw;
      text-align: center;
    }
  }

  .form-info {
    margin-bottom: -5px;
  }

  .filefromcomp {
    border-style: solid;
    border-width: 1px;
    border-color: beige;
    background-color: antiquewhite;
    display: flex;
    justify-content: center;
  }
</style>