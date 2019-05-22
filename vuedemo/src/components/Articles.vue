<template>
  <div>
    <h1>{{item.title}}</h1>
    <blockquote v-if="showFlag">作者:{{item.auther}},时间:{{item.date}}</blockquote>
    <h3 v-else>欢迎来到Maasteer's Blog</h3>
        <br>
        <br>
    <P class="text-justify">{{item.context}}</p>
  </div>
</template>
<script>
export default {
  name: 'articles', 
  data() {
    return {
      item:[],
      showFlag : false,
      id : -1   
    }
  },
  methods:{
    rightNavItemClick:function(id){
      var vm = this;
      var mainBlock = this.$refs.mainBlock;
      mainBlock.setId(id);
      //mainBlock.getData();
      //console.log(mainBlock.id);
    },
    getData:function(){
      var vm = this;
      if(vm.id < 0)
        vm.showFlag = false;
      else
      {
        vm.$http.get('http://localhost:6005/api/index/' + vm.id).then(function(response){
          console.log(response.data);
          vm.item = response.data;
          vm.showFlag = true;
        });
      }
    },
    setId:function(id){
      this.id = id;
      this.getData();
    }
  },
  created() {
    var vm = this;
    vm.setId(vm.$route.params.id);

    vm.getData();
  },
  watch: {
    '$route' (to, from) {
      var vm = this;
      vm.setId(vm.$route.params.id);
    }
  }
}


</script>

<style>
</style>
