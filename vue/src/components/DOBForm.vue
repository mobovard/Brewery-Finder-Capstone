<template>
  <div>
    <b-form>
      <b-form-datepicker
        v-model="value"
        v-bind="labels[locale] || {}"
        :locale="locale"
        :start-weekday="weekday"
        :show-decade-nav="showDecadeNav"
        :hide-header="hideHeader"
        class="mb-2"
      ></b-form-datepicker>
    </b-form>
  </div>
</template>

<script>
export default {
  data() {
    const now = new Date();
    const today = new Date(now.getFullYear(), now.getMonth(), now.getDate());
 
    const maxDate = new Date(today);
    maxDate.setMonth(maxDate.getMonth() - 252);
    maxDate.setDate(15);

    return {
      value: "",
      locale: "en-US",
      min: minDate,
      max: maxDate,
      showDecadeNav: true,
      hideHeader: false,
      weekday: 0,

      weekdays: [
        { value: 0, text: "Sunday" },
        { value: 1, text: "Monday" },
        { value: 6, text: "Saturday" },
      ],
    };
  },
};
</script>

<style>
</style>