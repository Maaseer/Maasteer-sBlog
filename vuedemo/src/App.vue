<template>
  <div id="app">
    <topNav></topNav>
    <div class="container-fluid" style="margin-top:80px">
        <div class="row">
            <mainBlock class="col-md-6 offset-md-1 border border-info" ></mainBlock>
            <right-nav class="col-md-3" style="margin-left: 10px" @rightNavItemClick="rightNavItemClick"></right-nav>
        </div>
    </div>
  </div>
</template>

<script>


import topNav from './components/topNav.vue';
import rightNav from'./components/rightNav.vue';
import mainBlock from './components/mainBlock';

export default {
  name: 'app',
  components: {
    topNav,rightNav,mainBlock
  },
  data() {
    return {
      mainBlockId:-1  
    }
  },
  methods:{
    rightNavItemClick:function(id){
      var vm = this;
      vm.mainBlockId = id;
      console.log(vm.mainBlockId);
    }
  }
}
</script>

<style>
@import "https://cdn.staticfile.org/twitter-bootstrap/4.1.0/css/bootstrap.min.css";
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
