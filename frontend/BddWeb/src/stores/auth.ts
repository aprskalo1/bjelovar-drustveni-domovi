import { CreateAxiosDefaults } from "axios";
import { defineStore } from "pinia";
import { computed, ref } from "vue";
import { createAxiosClient } from "../services/createAxiosClient";

interface Tokens {
  accessToken: string;
  refreshToken: string;
}

const REST_API_URL = ""; // Todo: import.meta.env.VITE_REST_API_URL;
const REFRESH_TOKEN_URL = `${REST_API_URL}/auth/refreshToken`;
const AXIOS_CLIENT_OPTIONS: CreateAxiosDefaults = {
  baseURL: REST_API_URL,
  timeout: 300000,
  headers: {
    "Content-Type": "application/json",
  },
};

function setTokensToLocalStorage({ accessToken, refreshToken }: Tokens) {
  localStorage.setItem("accessToken", accessToken);
  localStorage.setItem("refreshToken", refreshToken);
}

function removeTokensFromLocalStorage() {
  localStorage.removeItem("accessToken");
  localStorage.removeItem("refreshToken");
}

export const useAuthStore = defineStore("auth", () => {
  const accessToken = ref(localStorage.getItem("accessToken"));
  const refreshToken = ref(localStorage.getItem("refreshToken"));
  const isLoggedIn = computed(() => !!accessToken.value);

  const onLogin = (tokens: Tokens) => {
    setTokensToLocalStorage(tokens);
    accessToken.value = tokens.accessToken;
    refreshToken.value = tokens.refreshToken;
  };

  const onLogout = () => {
    removeTokensFromLocalStorage();
    accessToken.value = null;
    refreshToken.value = null;
  };

  const axiosClient = createAxiosClient({
    options: AXIOS_CLIENT_OPTIONS,
    getCurrentAccessToken: () => accessToken.value,
    getCurrentRefreshToken: () => refreshToken.value,
    refreshTokenUrl: REFRESH_TOKEN_URL,
    logout: onLogout,
    setRefreshedTokens: onLogin,
  });

  return {
    isLoggedIn,
    axiosClient,
  };
});
