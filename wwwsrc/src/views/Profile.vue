<template>
  <div class="Profile row">
    <div class="col-12 col-md-10 offset-md-1">
      <div class="row">
        <div class="col-9">
          <div class="row">
            <add-keep></add-keep>
            <div class="col-12 text-center mb-2 mt-1  ">
              <button type="button" class="btn addbtn" data-toggle="modal" data-target="#exampleModal">
                Add Keep
              </button>
            </div>
            <div class="col-12 scrolly">
              <div class="row">
                <private-keeps v-for="keep in keeps" :keeprData="keep"></private-keeps>
              </div>
            </div>
          </div>
        </div>
        <div class="col-3 col-md-2 offset-md-1">
          <div class="row">
            <div class="col-12">
              <button type="button" class="btn addbtn" data-toggle="modal" data-target="#VaultModal">Add
                Vault</button>
              <add-vault></add-vault>
            </div>
            <div class="col-11 offset-md-1 mt-2">
              <div class="row">
                <p-vaults v-for="vault in vaults" :vaultData="vault"></p-vaults>
              </div>
            </div>
          </div>
        </div>

      </div>
    </div>
  </div>
</template>


<script>
  import PVaults from "@/components/PVaults.vue"
  import AddVault from "@/components/AddVault.vue"
  import AddKeep from "@/components/AddKeep.vue"
  import PrivateKeeps from "@/components/PrivateKeeps.vue"

  export default {
    name: 'Profile',
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch('getVaults')
      this.$store.dispatch('getMyKeeps')
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "home" });
      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      },
      keeps() {
        return this.$store.state.keeps
      }
    },
    methods: {},
    components: {
      PVaults,
      AddVault,
      AddKeep,
      PrivateKeeps
    }
  }
</script>


<style scoped>
  .addbtn {
    background-color: #05004e;
    color: #f9f8eb;
    box-shadow: 3px 3px 5px rgba(0, 0, 0, 0.753);
  }

  @media only screen and (max-width: 600px) {
    .scrolly {
      overflow-y: scroll;
      height: 80vh;
    }
  }
</style>