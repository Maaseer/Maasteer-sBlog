<template>
    <nav id="top-nav" class="navbar navbar-expand-sm bg-dark navbar-dark fixed-top ">
        <router-link class="navbar-brand" to="/">Maasteer's blog</router-link>
        <ul class="navbar-nav ml-auto" >
            <li class="nav-item">
                <router-link class="nav-link" to="/">首页</router-link>
            </li>
            <li class="nav-item">
                <router-link class="nav-link" to="/message">留言</router-link>
            </li>
        </ul>
        <form class="form-inline flex-row-reverse">
                <button class="btn btn-primary" type="button">搜索</button>

                <input class="form-control" type="text" placeholder="Search">
        </form>
    </nav>
</template>

<script>
export default {
  name: 'topNav',
  props: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
