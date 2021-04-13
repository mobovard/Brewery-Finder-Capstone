<template>
  <tr role="row" class="text-wheat-h">
    <td aria-colindex="1" role="cell">
      {{ user.username }}
    </td>
    <td aria-colindex="2" role="cell" v-if="!isEdit">{{ user.role }}</td>
    <td aria-colindex="2" role="cell" v-if="isEdit">
      <b-form-select :options="roles" v-model="user.role"> </b-form-select>
    </td>
    <td aria-colindex="3" role="cell" v-if="!isEdit">
      {{ user.active ? "Active" : "Inactive" }}
    </td>
    <td aria-colindex="2" role="cell" v-if="isEdit">
      <b-form-select :options="status" v-model="user.active"> </b-form-select>
    </td>
    <td aria-colindex="4" role="cell">
      <button
        class="btn bg-porter text-foam text-wheat-h"
        @click="isEdit = !isEdit"
      >
        {{ isEdit ? "Save" : "Edit" }}
      </button>
      <button
        class="btn bg-porter text-foam text-wheat-h ml-2"
        v-if="isEdit"
        @click="
          setUserFromStore();
          isEdit = false;
        "
      >
        Cancel
      </button>
    </td>
  </tr>
</template>

<script>
export default {
  props: ["userId"],
  data() {
    return {
      isEdit: false,
      roles: ["Admin", "Brewer", "Beer Lover"],
      status: [
        { value: true, text: "Active" },
        { value: false, text: "Inactive" },
      ],
      user: {},
    };
  },
  created() {
    this.setUserFromStore();
  },
  methods: {
    setUserFromStore() {
      this.user = { ...this.$store.getters.getUser(this.userId) };
    },
  },
};
</script>
