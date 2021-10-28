import { StatusBar } from 'expo-status-bar';
import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import Icon from 'react-native-vector-icons/FontAwesome'

export default function App() {
  return (
    <View>
      <StatusBar style="light-content" />
      <View style={styles.headerContainer}>
          <View style={styles.inputContainer}>
            <Icon name="search" color="#969696" size={24} />
            <Text>Bạn tìm gì hôm nay2</Text>
          </View>
          <View style={styles.cartContainer}>
              <Icon name="shopping-cart" color="#969696" size={24} />
          </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  headerContainer: {
    flexDirection: 'row',
    paddingTop:50,
    paddingBottom:4,
    backgroundColor: '#1e88e5',
  },
  inputContainer: {
    backgroundColor: '#fff',
    flexDirection: 'row',
    flex: 1,
    marginLeft:10,
    alignItems:'center',
    marginBottom:4,
  },
  cartContainer: {

  },
});
