import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { RootStackParamList } from '../../interface/IRoutes';

const Home: React.FC<StackScreenProps<RootStackParamList, 'Home'>> = ({
  navigation,
}) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> Home</Text>
        <Button title="Search" onPress={() => navigation.navigate('Search')} />
      </View>
    </>
  );
};

export default Home;
