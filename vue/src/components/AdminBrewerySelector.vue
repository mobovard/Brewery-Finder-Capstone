<template>
  <div>
    <h4 class="text-foam text-center">Select Brewery</h4>
    <table
      role="table"
      aria-busy="false"
      class="table b-table table-striped table-borderless table-sm text-foam"
    >
      <tbody role="rowgroup">
        <tr
          role="row"
          v-for="brewery in $store.getters.adminBreweries"
          :key="brewery.brewery_id"
          class="text-wheat-h pointer"
          @click="
            $router.push({
              name: 'updateBrewery',
              params: { breweryId: brewery.brewery_id },
            })
          "
        >
          <td aria-colindex="1" role="cell">{{ brewery.name }}</td>
          <td aria-colindex="2" role="cell">
            {{ brewery.active ? "Active" : "Inactive" }}
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {};
</script>

<style>
.pointer {
  cursor: pointer;
}
</style>
