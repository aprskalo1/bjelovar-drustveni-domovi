import { defineStore } from "pinia";
import { URLS, useAuthStore } from "./auth";

export const useCentersStore = defineStore("centers", () => {
  const authStore = useAuthStore();

  const getCenters = async (startDate?: string, endDate?: string) => {
    const response = await authStore.axiosClient.get(
      URLS.GET_CENTERS_BY_AVAILABILITY,
      {
        params: {
          startDate,
          endDate,
        },
      },
    );
    return response.data as Center[];
  };

  return {
    getCenters,
  };
});
