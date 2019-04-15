<template>
  <div class="AddKeep col-12">
    ADD KEEP HERE
    <form class="row">
      <div class="col-3 form-group">
        <label for="KeepName"> Keep Title</label>
        <input type="text" class="form-control" placeholder="Enter desired keep name here">
      </div>
      <div class="col-3 form-group">
        <label for="KeepDesc"> Keep Description</label>
        <input type="text" class="form-control" placeholder="Enter keep description here">
      </div>
      <div class="col-3 form-group">
        <label for="KeepImg"> Keep Image</label>
        <input type="url" class="form-control" placeholder="Enter Url to Image here">
        <input type="file" class="form-control-file">
      </div>
      <div class="col-3 form-group">
        <button type="submit" class="btn btn-primary">Submit</button>
      </div>
    </form>

  </div>
</template>


<script>
  export default {
    name: 'AddKeep',
    data() {
      return {}
    },
    computed: {},
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>