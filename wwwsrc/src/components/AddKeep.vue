<template>
  <!-- Modal -->
  <div class="modal fade addkeep col-12" id="exampleModal" tabindex="-1" role="dialog"
    aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content modal-bg">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Add a new Keep!</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form class="row" @submit.prevent='createKeep()'>
            <div class="col-12 nkmodal">
              <input type="text" v-model="newKeep.name" class="form-control field"
                placeholder="Enter desired keep name here">
            </div>
            <div class="col-12 nkmodal">
              <input type="text" v-model="newKeep.description" class="form-control field"
                placeholder="Enter keep description here">
            </div>
            <div class="col-12 nkmodal">
              <input type="text" v-model="newKeep.img" class="form-control field" placeholder="Enter Image here">
            </div>
            <div class="col-12 nkmodal">
              <input type="checkbox" v-model="newKeep.isPrivate" value="true" class="form-control nkcheck">Mark as
              private?
            </div>
            <div class="col-12 subbtn">
              <hr>
              <button type="submit" class="btn addbtn">Submit</button>
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
          UserId: this.$store.state.user.id,
        }
      }
    },
    computed: {
    },
    methods: {
      createKeep() {
        this.$store.dispatch('CreateKeep', this.newKeep)
      }
    },
    components: {}
  }
</script>


<style scoped>
  .modal-bg {
    background-color: #f9f8eb;
  }

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

  .subbtn {
    margin-top: 10px;
  }

  .nkmodal {
    display: flex;
    justify-content: center;
    margin-bottom: 2vh;
  }

  .nkcheck {
    width: 20px;
    margin-top: -7px;
  }

  .addbtn {
    background-color: #05004e;
    color: #f9f8eb;
  }
</style>