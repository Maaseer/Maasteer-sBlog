<template>
  <div>
    <ul>
      <li>Title:{{item.title}}</li>
      
      <li>Auther:{{item.auther}}</li>
      <li>Date:{{item.date}}</li>
      <li>Remark:{{item.remark}}</li>
      <li>context:{{item.context}}</li>
      
      
    </ul>
     
  </div>
</template>

<script>
export default {
  name: 'mainBlockItem',
  props:['id'],
  data:function(){
      return {
          item:[]
      }
  },
  methods:{
    getData:function(){
      var vm = this;
      vm.$http.get('http://localhost:6000/api/index/' + id).then(function(response){
        vm.item = response.data;
        console.log(vm.item);
      });
    }
  },
  created() {
    this.getData();
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
