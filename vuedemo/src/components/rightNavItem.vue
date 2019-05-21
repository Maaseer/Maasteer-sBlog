<template>
    <div class="card bg-dark text-white" style="border-radius:0;" @click="rightItemClick">
      <div class="card-body">
        <h6 class="card-title">{{item.title}}</h6>
        <p class="card-text">auther:{{item.auther}}<br>date:{{item.date}}</p>
      </div>
  </div>
</template>

<script>
export default {
  name: 'rightItem',
  props:['item'],
  data:function(){
      return {
          
      }
  },
  methods:{
    rightItemClick:function () {
      var vm  = this;
      vm.$emit('itemClick',vm.item.id)
    }
  },
  created() {

  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
