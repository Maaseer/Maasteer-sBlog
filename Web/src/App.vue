<template>
  <div id="app">
    <topNav @searchClick="searchClick"></topNav>
    <div class="container-fluid" style="margin-top:80px">
      <div class="row">
      <div class="col-md-6 offset-md-2  border-info">
        <router-view ></router-view>
      </div>
      
      <div class="col-md-2" style="margin-left: 50px">
            <right-nav></right-nav>

      </div>   
      
      </div>
    </div>
  </div>
</template>

<script>


import topNav from './components/topNav.vue';

import rightNav from './components/rightNav.vue';

export default {
  name: 'app',
  components: {
    topNav,rightNav
  },
  data() {
    return {
    }
  },
  methods:{
      searchClick:function(searchStr){
        
      }
  }
}

</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
