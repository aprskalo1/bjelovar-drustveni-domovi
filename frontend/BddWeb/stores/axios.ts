import { defineStore } from "pinia";
import { createAxiosClient } from "../services/createAxiosClient";
import { useAuthStore } from "./auth";

interface EmailPassword {
  email: string;
  password: string;
}

const REST_API_URL = import.meta.env.VITE_REST_API_URL;
const REFRESH_TOKEN_URL = `${REST_API_URL}/auth/refreshToken`;

export const useAxiosStore = defineStore("axios", () => {
  const authStore = useAuthStore();

  const client = createAxiosClient({
    options: {
      baseURL: REST_API_URL,
      timeout: 300000,
      headers: {
        "Content-Type": "application/json",
      },
    },
    getCurrentAccessToken: () => authStore.accessToken,
    getCurrentRefreshToken: () => authStore.refreshToken,
    refreshTokenUrl: REFRESH_TOKEN_URL,
    logout: authStore.onLogout,
    setRefreshedTokens: authStore.onLogin,
  });

  const register = ({ email, password }: EmailPassword) => {
    return client.post(
      "auth/register",
      { email, password },
      { authorization: false },
    );
  };

  const login = ({ email, password }: EmailPassword) => {
    return client.post(
      "auth/login",
      { email, password },
      { authorization: false },
    );
  };

  const getProfile = () => {
    return client.get("/users/me");
  };

  const saveResourceFromXMLwithXSDvalidation = (xmlFile: File) => {
    const formData = new FormData();
    formData.append("file", xmlFile);
    return client.post("/resources/xml-xsd", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  };

  const saveResourceFromXMLwithRNGvalidation = (xmlFile: File) => {
    const formData = new FormData();
    formData.append("file", xmlFile);
    return client.post("/resources/xml-rng", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  };

  const checkTask3 = () => {
    return client.get("/check-task-3");
  };

  const getCurrentTemperature = (city = "") => {
    return client.get("/get-current-temperature?city=" + city);
  };

  const getErrorMessage = (responeError: any) => {
    return responeError?.response?.data?.message || responeError.message;
  };

  return {
    register,
    login,
    getProfile,
    saveResourceFromXMLwithXSDvalidation,
    saveResourceFromXMLwithRNGvalidation,
    checkTask3,
    getCurrentTemperature,
    getErrorMessage,
  };
});
