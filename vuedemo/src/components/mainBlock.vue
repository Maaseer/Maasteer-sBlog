<template>
  <div>
    <h1>{{item.title}}</h1>
    <h3>auther:{{item.auther}},date:{{item.date}}</h3>
    <P>{{item.context}}</p>
  </div>
</template>

<script>
import mainBlockItem from './mainBlockItem.vue'
export default {
  name: 'mainBlock',
  props:['id'],
  data() {
    return {
      item:[]   
    }
  },
  methods:{
    getData:function(){
      var vm = this;
      vm.$http.get('http://localhost:6000/api/index/' + vm.id).then(function(response){
        vm.item = response.data;
        console.log(vm.item);
      });
    }
  },
  created() {
  },
  updated() {
    this.getData();
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
