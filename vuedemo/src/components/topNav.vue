<template>
    <nav id="top-nav" class="navbar navbar-expand-sm bg-dark navbar-dark fixed-top ">
        <a class="navbar-brand" href="#">Maasteer's blog</a>
        <ul class="navbar-nav ml-auto" >
            <li class="nav-item">
            <a class="nav-link" href="#">首页</a>
            </li>
            <li class="nav-item">
            <a class="nav-link" href="#">留言</a>
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
