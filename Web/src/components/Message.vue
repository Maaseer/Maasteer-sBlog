<template>
  <div id="Message" >
      <h1>{{msg}}</h1>
  </div>
</template>

<script>
export default {
  name: 'Home',
  data:function(){
      return {
          items:[],
          msg:'留言功能待完成！'
      }
  },
  methods:{
    getData:function(){
      var vm = this;

    }
  },
  created() {
    //this.getData();
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1{
    margin: auto;
}
</style>
